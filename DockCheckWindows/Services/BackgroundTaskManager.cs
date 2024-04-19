using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using Newtonsoft.Json;

public class SerialDataProcessor
{
    private SerialPort _serialPort;
    private CancellationTokenSource _cancellationTokenSource;
    private EventRepository _eventRepository;
    private UserRepository _userRepository;
    private EmployeeRepository _employeeRepository;
    private Action<string> _updateStatusAction;
    private int _currentSlaveIndex;
    private List<string> _slavePcs;
    private DateTime _lastApprovedIdsSentDate;

    // Flag to indicate if the closest beacon ID should be captured
    public bool CaptureClosestBeaconId { get; set; } = false;

    // Property to store the closest beacon ID
    public string ClosestBeaconId { get; private set; } = string.Empty;

    public bool IsProcessingActive { get; private set; } = false;


    public SerialDataProcessor(EventRepository eventRepository, UserRepository userRepository, Action<string> updateStatusAction, EmployeeRepository employeeRepository)
    {
        _eventRepository = eventRepository;
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
        _updateStatusAction = updateStatusAction;
        _serialPort = new SerialPort("COM5", 115200);
        _cancellationTokenSource = new CancellationTokenSource();
        _currentSlaveIndex = 0;
       // _slavePcs = new List<string>(); // List to store slave PCs
        _slavePcs = new List<string> { "P1", "P1B", "P2", "P3", "P4", "P5", "P6" };
        _lastApprovedIdsSentDate = DateTime.MinValue;
    }

    public void PauseProcessing()
    {
        _updateStatusAction("Pausing serial processing");
        _cancellationTokenSource.Cancel();
        if (_serialPort.IsOpen)
        {
            _serialPort.Close();
            _serialPort.Dispose(); // Ensure complete closure
        }
        _updateStatusAction("Serial processing paused");
        Task.Delay(1000).Wait(); // Wait a bit longer for complete release
        IsProcessingActive = false; // Set to false when processing is paused
    }

    public async Task ResumeProcessingAsync()
    {
        _updateStatusAction("Resuming serial processing");
        _cancellationTokenSource = new CancellationTokenSource();

        // Recreate the serial port
        _serialPort = new SerialPort("COM5", 115200);

        await StartProcessingAsync();
    }

    public async Task StartProcessingAsync()
    {
        _updateStatusAction("Starting processing");
        try
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }

            if (DateTime.Now.Date < _lastApprovedIdsSentDate)
            {
                await SendApprovedIdsToAllSlavesAsync();

                _lastApprovedIdsSentDate = DateTime.Now.Date;
            }

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                for (_currentSlaveIndex = 0; _currentSlaveIndex < _slavePcs.Count; _currentSlaveIndex++)
                {
                    await ProcessCurrentSlaveAsync(_slavePcs[_currentSlaveIndex]);
                }
            }
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error in StartProcessingAsync: {ex.Message}");
            //MessageBox.Show($"Error: {ex.Message}", "Error");
        }

        IsProcessingActive = true; // Set to true when processing starts
    }


    private async Task SendApprovedIdsToAllSlavesAsync()
    {
        try
        {
            ApprovedEmployeesResponse response = await _employeeRepository.GetAllApprovedEmployeesAsync();
            string approvedIds = FormatUsersData(response.Ids);

            foreach (var slavePc in _slavePcs)
            {
                bool success = await AttemptSendingApprovedIds(slavePc, approvedIds);
                if (!success)
                {
                    _updateStatusAction($"Failed to receive A OK from {slavePc}, retrying...");
                    success = await AttemptSendingApprovedIds(slavePc, approvedIds);
                    if (!success)
                    {
                        _updateStatusAction($"Failed to send approved IDs to {slavePc} after retrying, moving to next slave.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // General exception handling
            _updateStatusAction($"Error in SendApprovedIdsToAllSlavesAsync: {ex.Message}");
            // MessageBox.Show($"Error: {ex.Message}", "Error in Approval Sync");
        }
    }



    private string FormatUsersData(List<string> ids)
    {
        var builder = new StringBuilder();
        foreach (var id in ids)
        {
            builder.AppendLine(id + ",");
        }
        Console.WriteLine(builder.ToString());
        return builder.ToString();
    }

    private async Task<bool> AttemptSendingApprovedIds(string slavePc, string approvedIds)
    {
        await SendCommandAsync($"{slavePc} A,{approvedIds}");
        return await WaitForResponseAsync($"{slavePc} A OK", 3);
    }

    public async Task SendApprovedIdAsync(string slavePc, string id)
    {
        _updateStatusAction($"Sending approved ID to {slavePc}");
        await SendCommandAsync($"{slavePc} A,{id}");
        if (!(await WaitForResponseAsync($"{slavePc} A OK", 3)))
        {
            _updateStatusAction($"Failed to receive A OK from {slavePc}, retrying...");
            if (!(await WaitForResponseAsync($"{slavePc} A OK", 3)))
            {
                _updateStatusAction($"Failed to send approved ID to {slavePc} after retrying.");
                // Handle the failure case, e.g., log the error, notify the user, etc.
            }
        }
    }

    private async Task ProcessCurrentSlaveAsync(string currentPc)
    {
        _updateStatusAction($"Processing {currentPc}");

        try
        {
            await SendCommandAsync($"{currentPc} OK");
            if (await WaitForResponseAsync($"{currentPc} Yes", 3))
            {
                await SendCommandAsync($"{currentPc} SDATAFULL");
                if (await ProcessDataAsync(currentPc))
                {
                    await SendCommandAsync($"{currentPc} CLDATA");
                    _updateStatusAction("Dados recebidos com sucesso");

                    await Task.Delay(1000); // 10 seconds timeout
                }
            }
            else
            {
                _updateStatusAction($"{currentPc} did not respond with 'Yes'.");
            }
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error in ProcessCurrentSlaveAsync for {currentPc}: {ex.Message}");
          //  MessageBox.Show($"Error processing {currentPc}: {ex.Message}", "Error");
        }
        // The method exits after processing one slave, allowing the next iteration for the next slave.
    }

    private async Task<bool> WaitForResponseAsync(string expectedResponse, int timeoutInSeconds)
    {
        int attempts = 0;
        const int maxAttempts = 2;

        while (attempts < maxAttempts)
        {
            _updateStatusAction($"Attempt {attempts + 1} of {maxAttempts}: Waiting for response: {expectedResponse}");
            string response = await ReadLineAsync(timeoutInSeconds * 1000);

            if (response?.Contains(expectedResponse) == true)
            {
                _updateStatusAction($"Received expected response: {response}");
                return true;
            }

            attempts++;
            if (attempts < maxAttempts)
            {
                await SendCommandAsync($"{expectedResponse.Substring(0, 2)} OK");
            }
        }

        _updateStatusAction($"Failed to receive '{expectedResponse}' after {maxAttempts} attempts.");
        return false;
    }

    private async Task SendCommandAsync(string command)
    {
        Console.WriteLine("Send Cmomand Async");
        try
        {
            if (_serialPort.IsOpen) { 
            _updateStatusAction($"Sending command: {command}");
            await Task.Run(() => _serialPort.WriteLine(command));
        } else
            {
            _updateStatusAction($"Serial port is not open, attempting to open.");
            _serialPort.Open();
            _updateStatusAction($"Sending command: {command}");
            await Task.Run(() => _serialPort.WriteLine(command));
            }
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error sending command {command}: {ex.Message}");
            //MessageBox.Show($"Error sending command {command}: {ex.Message}", "Error");
        }
    }

    private async Task<bool> ProcessDataAsync(string pc)
    {
        bool dataReceived = false;
        bool startDataFlag = false;
        bool endDataFlag = false;

        _updateStatusAction($"Waiting for data from {pc}");
        Console.WriteLine("Process Data");
        try
        {
            string line;
            while ((line = await ReadLineAsync(10000)) != null)
            {
                Console.WriteLine(line);
                if (line.StartsWith($"{{{pc}"))
                {
                    startDataFlag = true;
                    continue;
                }

                if (line.StartsWith("}") && startDataFlag)
                {
                    endDataFlag = true;
                    break;
                }

                if (startDataFlag && !string.IsNullOrWhiteSpace(line))
                {
                    dataReceived = true;
                    Event evt = ParseEventFromLine(line, pc);
                    if (evt != null)
                    {
                        await _eventRepository.CreateEventAsync(evt);
                    }
                }
            }

            if (endDataFlag && dataReceived)
            {
                // Send CLDATA only if data was actually received
                await SendCommandAsync($"{pc} CLDATA");
                _updateStatusAction("CLDATA command sent.");
            }

            return dataReceived;
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error processing data for {pc}: {ex.Message}");
            return false;
        }
    }

    private string ExtractBeaconIdFromLine()
    {
        try
        {
            // Send the command to get the nearest beacon ID
            _serialPort.WriteLine("L1");

            // Wait for the response with a specified timeout
            _serialPort.ReadTimeout = 5000; // Timeout in milliseconds, adjust as needed
            return _serialPort.ReadLine(); // Read the nearest beacon ID
        }
        catch (TimeoutException)
        {
            _updateStatusAction("Timeout occurred while reading the nearest beacon ID.");
            return null; // Return null on timeout
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error while reading the nearest beacon ID: {ex.Message}");
            return null; // Return null on error
        }
    }



    private async Task<string> ReadLineAsync(int timeout)
    {
        Console.WriteLine("Read Line Async");
        try
        {
            if (!_serialPort.IsOpen)
            {
                _updateStatusAction("Serial port is not open, attempting to open.");
                _serialPort.Open();
            }

            _serialPort.ReadTimeout = timeout;
            var buffer = new StringBuilder();
            var endTime = DateTime.Now.AddMilliseconds(timeout);

            while (DateTime.Now < endTime)
            {
                if (_serialPort.BytesToRead > 0)
                {
                    var data = (char)_serialPort.ReadChar();
                    if (data == '\n')
                    {
                        return buffer.ToString();
                    }
                    buffer.Append(data);
                }
                else
                {
                    await Task.Delay(50); // Brief delay to avoid tight loop
                }
            }
        }
        catch (TimeoutException)
        {
            _updateStatusAction("ReadLineAsync timeout occurred.");
            return null; // Return null on timeout
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error in ReadLineAsync: {ex.Message}");
          //  MessageBox.Show($"Error in ReadLineAsync: {ex.Message}", "Read Error");
            return null;
        }

        _updateStatusAction("ReadLineAsync timeout occurred. No data received.");
        return null; // Return null if no data received within timeout
    }



    private Event ParseEventFromLine(string line, string pCode)
    {
        Console.WriteLine("Parse event");
        // Assuming the line format: "{PN 2024-01-11 14:24:42 ff:ff:10:e2:34:06,L1"
        try
        {
            string[] parts = line.Split(new[] { ' ' }, 3);
            if (parts.Length != 3) return null;

            string timestampPart = parts[1];
            string dataPart = parts[2];

            DateTime timestamp;
            if (!DateTime.TryParse(timestampPart, out timestamp))
            {
                _updateStatusAction($"Invalid timestamp format in line: {line}");
                return null;
            }

            string[] dataParts = dataPart.Split(',');
            if (dataParts.Length < 2) return null;
            string rssi = "0";
            string actionCode = "8";
            string beaconId = dataParts[0].Trim();
            if (dataParts.Length > 2)
            {
                rssi = dataParts[1].Trim();
                actionCode = dataParts[2].Trim();
            }

            if (dataParts.Length == 2)
            {
                actionCode = dataParts[1].Trim();
            }
            Console.WriteLine($"Beacon ID: {beaconId}, RSSI: {rssi}, Action Code: {actionCode}");
            return new Event
            {
                Id = Guid.NewGuid().ToString(),
                SensorId = pCode,
                EmployeeId = "-",
                Timestamp = timestamp,
                ProjectId = "4f24ac1f-6fd3-4a11-9613-c6a564f2bd86",
                Action = GetActionFromCode(actionCode) >= 0 ? GetActionFromCode(actionCode) : 0,
                BeaconId = beaconId,
                Status = "sent"
            };
        }
        catch (Exception ex)
        {
            _updateStatusAction($"Error parsing line: {ex.Message}");
            return null;
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
 - Everyday ONCE PER DAY the Master should fetch the approved IDs from the Backend with the GetAllApprovedUsersAsync() method and send it to each Slave with the "PN A," command, with each ID separated by comma after the "A," without any space after the "A,".
 - If the Slave returns "PN A OK" we are done for this day and just send this again to the Slave at the next day.
 - If the Slave do not returns "PN A OK" we jump to the next slave (if there are any) or we try again (if there are just one slave)

Plus:
 - The class should have a public pause and resume function, so other parts of the code can use the PORT COM5 without any problem
 - The class should have a function to send the "PN A," command which receives a code to be sent with the command, in case we add a new user during the day, we send the id of the new user with this command as "PN A,xx:xx:xx:xx:xx:xx" where xx:xx:xx:xx:xx:xx is the string structure of the ID
- The code should all be commented
- The code needs to follow the good practices of the .NET and C# conventions.
- The code should be as efficient as possible
- The code needs to handle all the possible error scenarios effectivly

*/

