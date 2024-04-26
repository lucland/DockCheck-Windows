using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using DockCheckWindows.Models;
using Newtonsoft.Json;
using System.Net.Http;
using DockCheckWindows.Repositories;
using System.Linq;

public class SerialDataProcessor
{
    private SerialPort _serialPort;
    private CancellationTokenSource _cancellationTokenSource;
    private EventRepository _eventRepository;
    private List<string> _slavePcs;
    private Action<string> _updateStatusAction;
    private DateTime _lastApprovedIdsSentDate;
    private bool _isProcessingActive = false;
    private string _currentPCode = string.Empty;
    private ManualResetEvent _responseReceived = new ManualResetEvent(false);
    private StringBuilder _dataBuffer = new StringBuilder();
    private DateTime _lastSuccessfulOperation;
    private System.Timers.Timer _watchdogTimer;

    // Constructor initializes the serial port and other components
    public SerialDataProcessor(EventRepository eventRepository, Action<string> updateStatusAction)
    {
        InitializeSerialPort();
        _slavePcs = new List<string> { "P1", "P2", "P3", "P4", "P5", "P6", "P8", "P9" };
        _lastApprovedIdsSentDate = DateTime.MinValue;
        _eventRepository = eventRepository;
        _updateStatusAction = updateStatusAction;
        _watchdogTimer = new System.Timers.Timer(30000); // Check every 30 seconds
        _watchdogTimer.Elapsed += CheckForStall;
        _watchdogTimer.AutoReset = true;
        _watchdogTimer.Start();
    }

    private void InitializeSerialPort()
    {
        _serialPort = new SerialPort("COM5", 115200);
        _serialPort.DataReceived += OnDataReceived;
        _serialPort.ErrorReceived += OnErrorReceived;
    }

    private void CheckForStall(object sender, System.Timers.ElapsedEventArgs e)
    {
        if ((DateTime.Now - _lastSuccessfulOperation).TotalMinutes > 5) // Use a more generous timeout
        {
            Console.WriteLine("System appears to be stalled. Attempting to restart processing...");
            _watchdogTimer.Stop();  // Stop the timer to prevent multiple restart attempts
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            StartProcessingAsync();
        }
    }


    private void RestartProcessing()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();  // Ensure to cancel the current processing task
        }

        _updateStatusAction("Restarting the serial processing cycle.");
        Task.Run(() => StartProcessingAsync());  // Restart processing on a new task to avoid blocking
    }


    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            string incomingData = _serialPort.ReadExisting();
            if (string.IsNullOrEmpty(incomingData))
            {
                return;  // If no data or null string is read, safely return without processing.
            }

            Console.WriteLine($"Received Raw Data: {incomingData}"); // Log raw incoming data for debugging.

            _dataBuffer.Append(incomingData);

            // Process each complete line as it comes.
            ProcessBufferedData();
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error while receiving data: {ex.Message}");
            // Handle or log the error gracefully.
            
        }
    }

    private void ProcessBufferedData()
    {
        string bufferContent = _dataBuffer.ToString();
        int indexOfLastNewLine = bufferContent.LastIndexOf('\n');

        if (indexOfLastNewLine == -1)
        {
            return; // No complete line(s) to process yet.
        }

        // Get complete lines that end with a newline character, safely handle the substring operation.
        string completeData = bufferContent.Substring(0, indexOfLastNewLine + 1);
        _dataBuffer.Remove(0, indexOfLastNewLine + 1);  // Safely remove processed data from buffer.

        string[] lines = completeData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            ProcessLine(line.Trim());
        }
    }



    private void ProcessLine(string line)
    {
        try
        {
            if (line.StartsWith("{") || line.StartsWith("}"))
            {
                Console.WriteLine($"Ignored control line: {line}");
                return;
            }

            Event evt = ParseEventFromLine(line, _currentPCode);
            if (evt != null)
            {
                Console.WriteLine($"Parsed event: {JsonConvert.SerializeObject(evt)}");
                Task.Run(async () => await SendEventToBackendAsync(evt)); // Ensure the task is awaited
            }
            else
            {
                Console.WriteLine("Failed to parse line into an event.");
            }
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error parsing line: {ex.Message}");
        }
    }




    private void OnErrorReceived(object sender, SerialErrorReceivedEventArgs e)
    {
        _updateStatusAction("Serial port error received.");
    }

    public async Task StartProcessingAsync()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
        }
        _cancellationTokenSource = new CancellationTokenSource();

        try
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                _updateStatusAction("Serial port opened.");
            }
            await ProcessCycleAsync();
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error during processing: {ex.Message}");
            Console.WriteLine($"Restarting due to error: {ex.Message}");
            await StartProcessingAsync();  // Recursive restart on error
        }
    }


    private async Task ProcessCycleAsync()
    {
        if (!_serialPort.IsOpen)
        {
            try
            {
                _serialPort.Open();
                _updateStatusAction("Serial port opened.");
            }
            catch (Exception ex)
            {
                _updateStatusAction($"Failed to open serial port: {ex.Message}");
                return;  // Early exit if we cannot open the serial port
            }
        }

        // Ensuring that last operation timestamp is updated only once per complete cycle
        _lastSuccessfulOperation = DateTime.Now;  // Update at the start of processing cycle

        foreach (var slave in _slavePcs)
        {
            _currentPCode = slave;
            _updateStatusAction($"Processing slave {_currentPCode}.");
            try
            {
                if (await SendAndWaitForConfirmation(slave))
                {
                    await RequestAndProcessData(slave);
                }
                else
                {
                    _updateStatusAction($"Failed to receive confirmation from {slave}. Skipping to next slave.");
                }
            }
            catch (Exception ex)
            {
                _updateStatusAction($"Error while processing {slave}: {ex.Message}. Moving to next slave.");
            }
        }

        _lastSuccessfulOperation = DateTime.Now;  // Update after the cycle completes successfully
    }


    private async Task<bool> SendAndWaitForConfirmation(string slaveId)
    {
        Console.WriteLine("Send and Wait For Confirmation");
        _updateStatusAction($"Sending 'OK' command to {slaveId}.");
        for (int i = 0; i < 2; i++)
        {
            _serialPort.WriteLine($"{slaveId} OK");
            Console.WriteLine(slaveId);
            //wait two seconds
            Task.Delay(1000);

            if (await WaitForResponseAsync($"{slaveId} Yes", TimeSpan.FromSeconds(3)))
            {

                Console.WriteLine(slaveId);
                _updateStatusAction($"{slaveId} confirmed with 'Yes'.");
                return true;
            }
            else
            {
                _updateStatusAction($"No confirmation from {slaveId}, attempt {i + 1}.");
            }
        }
        return false;
    }

    private async Task<bool> WaitForResponseAsync(string expectedResponse, TimeSpan timeout)
    {
        Console.WriteLine("Wait for response async");
        _responseReceived.Reset(); // Reset the event

        // Issue the command expecting a response
        _serialPort.WriteLine($"{_currentPCode} OK");

        // Wait for the response or timeout
        bool received = _responseReceived.WaitOne(timeout);
        if (!received)
        {
            _updateStatusAction($"Timeout or wrong response after waiting for {expectedResponse}.");
            return false;
        }
        _updateStatusAction($"{expectedResponse} received.");
        return true;
    }

    private async Task<string> ReadLineAsync(TimeSpan timeout)
    {
        var taskCompletionSource = new TaskCompletionSource<string>();
        var timer = new System.Timers.Timer(timeout.TotalMilliseconds) { AutoReset = false };
        timer.Elapsed += (sender, e) =>
        {
            timer.Stop();
            taskCompletionSource.TrySetResult(null); // Null indicates timeout
            _updateStatusAction("Timeout occurred while reading line.");
        };

        timer.Start();

        StringBuilder result = new StringBuilder();
        try
        {
            while (_serialPort.IsOpen && !taskCompletionSource.Task.IsCompleted)
            {
                if (_serialPort.BytesToRead > 0)
                {
                    char readChar = (char)_serialPort.ReadChar();
                    result.Append(readChar);
                    if (readChar == '\n')
                    {
                        timer.Stop();
                        taskCompletionSource.SetResult(result.ToString().Trim());
                        break;
                    }
                }
                else
                {
                    await Task.Delay(10); // Brief delay to avoid tight loop
                }
            }
        }
        catch (Exception ex)
        {
            timer.Stop();
            taskCompletionSource.SetException(ex);
            _updateStatusAction($"Error while reading line: {ex.Message}");
        }

        return await taskCompletionSource.Task;
    }

    private async Task FetchAndSendApprovedIDs()
    {/*
        try
        {
            var approvedIds = await GetAllApprovedIDsAsync();
            string concatenatedIds = String.Join(",", approvedIds);
            foreach (var slave in _slavePcs)
            {
                await SendCommandAsync($"{slave} A,{concatenatedIds}");
                bool isAcknowledged = await WaitForResponseAsync($"{slave} A OK", TimeSpan.FromSeconds(3));
                if (!isAcknowledged)
                {
                    Console.WriteLine($"Warning: {slave} did not acknowledge the approved IDs.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching or sending approved IDs: {ex.Message}");
        }*/
    }


    private async Task ProcessDataAsync(string data, string pCode)
    {
        string[] lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        List<Task> tasks = new List<Task>();

        foreach (var line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                Event evt = ParseEventFromLine(line, pCode);
                if (evt != null)
                {
                    tasks.Add(SendEventToBackendAsync(evt));  // Collect tasks for each event being sent
                }
                else
                {
                    Console.WriteLine($"Failed to parse line into an event: {line}");
                }
            }
        }

        if (tasks.Any())
        {
            await Task.WhenAll(tasks);  // Wait for all events to be sent to the backend
        }

        // Send the clear data commands after all data has been processed and sent
        _serialPort.WriteLine($"{pCode} CLDATA");
        _serialPort.WriteLine($"{pCode} CLDATA2");
        _updateStatusAction($"Data cleared on {pCode} after processing.");
    }


    private async Task<bool> RequestAndProcessData(string slaveId)
    {
        _updateStatusAction($"Requesting data from {slaveId}.");
        _serialPort.WriteLine($"{slaveId} SDATAFULL");

        StringBuilder dataBuilder = new StringBuilder();
        bool endOfDataBlockDetected = false;

        while (!endOfDataBlockDetected)
        {
            var line = await ReadLineAsync(TimeSpan.FromSeconds(10));
            if (line == null)
            {
                _updateStatusAction($"Timeout or no more data received from {slaveId}. Moving to next slave.");
                return false;
            }

            if (line.Contains("}"))
            {
                endOfDataBlockDetected = true;
            }
            else
            {
                dataBuilder.AppendLine(line);
            }
        }

        if (dataBuilder.Length > 0)
        {
            await ProcessDataAsync(dataBuilder.ToString(), slaveId);
        }
        return true;
    }


    private Event ParseEventFromLine(string line, string pCode)
    {
        Console.WriteLine($"Attempting to parse line: {line}");
        string[] parts = line.Trim().Split(new[] { ' ' }, 3);
        if (parts.Length != 3 || !DateTime.TryParse(parts[1], out DateTime timestamp))
        {
            Console.WriteLine($"Invalid line format or timestamp: {line}");
            return null; // Reject lines that do not meet the format requirements
        }

        string[] dataParts = parts[2].Split(',');
        if (dataParts.Length < 2)
        {
            Console.WriteLine($"Insufficient data in line: {line}");
            return null; // Ignore lines with insufficient data parts
        }

        string beaconId = dataParts[0].Trim();
        string rssi = dataParts.Length > 1 ? dataParts[1].Trim() : "0";
        string actionCode = dataParts.Length > 2 ? dataParts[2].Trim() : "L1";

        Event evt = new Event
        {
            Id = Guid.NewGuid().ToString(),
            SensorId = pCode,
            EmployeeId = "-",
            Timestamp = timestamp,
            ProjectId = "4f24ac1f-6fd3-4a11-9613-c6a564f2bd86",
            Action = GetActionFromCode(actionCode),
            BeaconId = beaconId,
            Status = "sent"
        };

        Console.WriteLine($"Parsed event: {JsonConvert.SerializeObject(evt)}");
        return evt;
    }


    private async Task SendEventToBackendAsync(Event evt)
    {
        try
        {
            var response = await _eventRepository.CreateEventAsync(evt);
            if (response != null && response.Id != null)
            {
                Console.WriteLine($"Event successfully sent to backend with ID: {response.Id}");
            }
            else
            {
                Console.WriteLine("Failed to send event to backend or invalid response received.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending event to backend: {ex.Message}");
        }
    }

    public void PauseProcessing()
    {
        _serialPort.Close();
        _updateStatusAction("Serial processing paused.");
    }

    public async Task ResumeProcessingAsync()
    {
        if (!_serialPort.IsOpen)
        {
            _serialPort.Open();
            _updateStatusAction("Serial processing resumed.");
        }
        await StartProcessingAsync();  // Assumes non-cancelled token for simplicity 
    }


    private void ProcessIncomingData(string data, string pCode)
    {
        string[] commands = data.Split('\n');  // Split by new line which is considered as end of a command

        foreach (var command in commands)
        {
            var trimmedCommand = command.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedCommand) && trimmedCommand != "}")
            {
                // Ignore the opening bracket and any empty lines
                if (trimmedCommand.StartsWith("{")) continue;

                // Assuming each command is a data line to be turned into an event
                try
                {
                    Event evt = ParseEventFromLine(trimmedCommand, pCode);
                    if (evt != null)
                    {
                        // Asynchronously send to the backend or queue for sending
                        Task.Run(() => SendEventToBackendAsync(evt));
                    }
                }
                catch (Exception ex)
                {
                    _updateStatusAction($"Error processing command: {ex.Message}");
                }
            }
        }
    }


    private int GetActionFromCode(string code)
    {
        if (code.Contains(" "))
        {
            code = code.Split(' ')[0];
        }

        switch (code)
        {
            case "F1":
                return (int)ActionEnum.Avistado;
            case "F0":
                return (int)ActionEnum.Avistado;
            case "L1":
                return (int)ActionEnum.Perdido;
            case "L0":
                return (int)ActionEnum.Perdido;
            default:
                return -1;
        }
    }


}

//STL = PROXIMO E LIBERADO
//STB = PROXIMO E BLOQUEADO
//F0 = FIND NAO CADASTRADO
//F1 = FIND CADASTRADO
//L0 = LOST NAO CADASTRADO
//L1 = LOST CADASTRADO

//P0 manda para todos

//SDATA = SOLICITA DADOS
//CLDATA = LIMPA DADOS
//CLALL = LIMPA TODOS OS DADOS
//CL,xx:xx:xx:xx:xx:xx = LIMPA UM DADO ESPECIFICO
//A = APROVADO
//RSSI,-10 = RSSI MINIMO, APEMAS NUMEROS NEGATIVOS
//SL = RETORNA LISTA COMPLETA DE CADASTRADOS
//PX ST,2023-12-18 13:52:44
//CLP xx:xx:xx:xx:xx:xx = apaga beacon do portalo
//PX CLALLPLID = apaga todos os beacons do portalo
//PX SPLID = mostra os beacons do portalo
//PX PLID,xx:xx:xx:xx:xx:xx = adiciona beacon ao portalo
//PX MAXRSSI,-100 = seta o rssi minimo para o portalo

//P1 BTV
//P2 BATERRY VOLTAGE: 14.19

//Example of the data sent by the slave after a PN SDATA command:
/*
{PN
2024-01-11 14:24:42 ff:ff:10:e2:34:06,L1
2024-01-11 14:25:08 ff:ff:10:e2:34:06,F1
2024-01-11 14:25:37 ff:ff:10:e2:34:06,F1 STL
2024-01-11 14:25:39 ff:ff:10:e2:34:06,F1 STL
2024-01-11 14:45:37 ff:ff:10:e2:34:06,F1
2024-01-11 14:45:57 ff:ff:10:e2:33:64,F0 STB
2024-01-11 14:45:59 ff:ff:10:e2:33:64,F0 STB
2024-01-11 14:46:07 ff:ff:10:e2:33:64,F0 STB
2024-01-11 14:46:43 ff:ff:10:e2:33:64,F0 STB
2024-01-11 14:48:11 ff:ff:10:e2:34:06,F1
2024-01-11 14:50:58 ff:ff:10:e2:34:06,L1
}
*/

/*
BUSINESS RULES

Here is the Buisiness Logic I want to implement and the current code I have, can you analyze the code, think about the possible error scenarios and improve the code as whole so it turns into a consistent and error proof code?

What it must do:
 - This code is a Master, which communicates with N slaves via Serial Port communication, it must send data to the slaves, retrieve data, process the data and send the data to the backend successfully.
 - It should work 100% asyncronously, and it should never stop with an exception or timeout, it will follow a certain cycle and if for some reason the cycle gets broken, it should not interfeer with the rest of the software and restart the cycle again, never stopping the cycle.
 - It should display in the UI with the _updateStatusAction function the current step of the cycle and the current PN of the cycle.
- If it returns any exception, for example if we do not receive any awnser of the Slave, we should show a MessageBox to the User and try again the action, never stopping for any reason.


The cycle rules:
 1 - We open the Serial port (if not opened) and retrieve the number of slaves it should cycle through.
2 - If it has only one slave, it will always cycle through it, if there are more then one, it start the cycle of the first one and just start the cycle of the second slave if the first one finishes successfully or get stuck some how, and so on.
3 - The next step of the cycle should just start when the last one finishes or gets stucked somehow.

The cycle process:
1 - The first thing of the cycle is to send the serial command to the slave as "PN OK" where N is number of the slave (P1, P2, P3... and so on).
2 - After sending the OK command, it will keep checking if it receives the "PN Yes" awnser. 
2.1 - If it does not receive any "PN Yes" after 3 seconds, it should send "PN OK" again and wait again for the "PN Yes"
2.2 - If it send the "PN OK" two times and it still didnt receive an awnser,  it should jump to the next slave cycle.
3 - When receiving "PN Yes" successfully, it should send the command "PN SDATA" to request the data load of the slave.
3.1 - The slave will always start the awnser with a "{PN" line
3.2 - The slave will always finish the awnser with a "}" line
3.3 - While we do not receive the "}" awnser, we should retrieve each line, turn each line into a Event object and send this object to the API.
4 - After successfully receiving the "}" and successfully sending all of the received data to the Backend, we should send the command "PN CLDATA", so it clears the fetched data, we will not receive any awwnser for this command
5 - After sending the "PN CLDATA" we start the cycle again with the next PN (or with the same one if it is the only one).

Another functionality it should have:
 - At the beggining of every CYCLE the Master should fetch the approved IDs from the Backend with the GetAllApprovedUsersAsync() method and send it to all Slaves with the "P0 A," command, with each ID separated by comma after the "A," without any space after the "A,".

Plus:
 - The class should have a public pause and resume function, so other parts of the code can use the PORT COM5 without any problem
 - The class should have a function to send the "PN A," command which receives a code to be sent with the command, in case we add a new user during the day, we send the id of the new user with this command as "PN A,xx:xx:xx:xx:xx:xx" where xx:xx:xx:xx:xx:xx is the string structure of the ID
- The code should all be commented
- The code needs to follow the good practices of the .NET and C# conventions.
- The code should be as efficient as possible
- The code needs to handle all the possible error scenarios effectivly

*/

