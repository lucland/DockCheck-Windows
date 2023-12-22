using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using DockCheckWindows.Models;
using DockCheckWindows.Repositories;

public class SerialDataProcessor
{
    private SerialPort _serialPort;
    private CancellationTokenSource _cancellationTokenSource;
    private List<string> _receivedPCodes;
    private EventRepository _eventRepository;
    private Action<string> _updateStatusAction; // Delegate for updating status in Form1
    private bool _processingEnded = false;

    public SerialDataProcessor(EventRepository eventRepository, Action<string> updateStatusAction)
    {
        _eventRepository = eventRepository;
        _updateStatusAction = updateStatusAction;
        _serialPort = new SerialPort("COM7", 115200);
        _cancellationTokenSource = new CancellationTokenSource();
        _receivedPCodes = new List<string>();
    }

    public void StartProcessing()
    {
        try
        {
            _serialPort.Open();
            //MessageBox.Show("Serial port opened successfully.", "Information");
            _serialPort.WriteLine("P3 CLDATA");
            Task.Run(() => CheckPCodesAsync());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open serial port: {ex.Message}", "Error");
        }
    }

    private async Task CheckPCodesAsync()
    {
        while (_receivedPCodes.Count == 0)
        {
            for (int i = 3; i <= 3; i++)
            {
                string pCode = $"P{i}";
                _serialPort.WriteLine($"{pCode} ok");
                //MessageBox.Show($"Sent: {pCode} ok", "Command Sent");
                if (await WaitForPCodeResponse(pCode))
                {
                    _updateStatusAction($"{pCode} está disponível");
                  //  MessageBox.Show(pCode);
                    _receivedPCodes.Add(pCode);
                   // MessageBox.Show($"P Code {pCode} is available.", "P Code Available");
                  //  MessageBox.Show($"P Code {pCode} is available.", "P Code Available");
                }
            }

            foreach (var pCode in _receivedPCodes)
            {
              //  MessageBox.Show($"Processing data for {pCode}", "Processing Data");
                await ProcessPCodeDataAsync(pCode);
            }
        }
    }

    private async Task<bool> WaitForPCodeResponse(string pCode)
    {
        _updateStatusAction($"Waiting for response from {pCode}");
        var timeout = Task.Delay(10000);
        var readTask = ReadLineAsync();

        var completedTask = await Task.WhenAny(timeout, readTask);
        if (completedTask == readTask)
        {
           // MessageBox.Show($"Received: {readTask.Result}", "Response Received");
            string response = await readTask;
           // MessageBox.Show($"Received: {response}", "Response Received");
            return response.Contains("Yes");
        }
        return false;
    }

    private async Task<string> ReadLineAsync()
    {
        //MessageBox.Show("Waiting for response...", "Waiting");
        return await Task.Run(() => _serialPort.ReadLine());
    }

    private async Task ProcessPCodeDataAsync(string pCode)
    {
        _serialPort.WriteLine($"{pCode} SDATA");
       // MessageBox.Show($"Sent: {pCode} SDATA", "Command Sent");
        _updateStatusAction($"Receiving data from {pCode}");

        string line;
        List<Event> events = new List<Event>();

        while (true)
        {
            line = _serialPort.ReadLine();
            //MessageBox.Show($"Received: {line}", "Data Received");

            if (line == "}") // Check for the closing bracket
            {
                MessageBox.Show("Closing bracket received.", "Data Complete");
                break; // Exit the loop when '}' is received
            } else
            {
                Event evt = ParseEventFromLine(line, pCode);
                if (evt != null)
                {
                    events.Add(evt);
                    await _eventRepository.CreateEventAsync(evt);
                    //MessageBox.Show($"Parsed event: {evt.ToJson()}", "Event Parsed");
                    _updateStatusAction($"Data received from {pCode}");
                }
            }
        }

        // Send CLDATA command after exiting the loop
        _serialPort.WriteLine($"{pCode} CLDATA");
        MessageBox.Show($"Sent: {pCode} CLDATA", "Command Sent");
        _updateStatusAction($"Data processing completed for {pCode}");
    }


    private Event ParseEventFromLine(string line, string pCode)
    {
       // MessageBox.Show($"Parsing line: {line}", "Parsing Line");
        string[] parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3) return null;
        DateTime timestamp;

        //MessageBox.Show($"Parsing timestamp: {parts[0]}", "Parsing Timestamp");
        //MessageBox.Show($"Parsing beacon code: {parts[1]}", "Parsing Beacon Code");
       // MessageBox.Show($"Parsing action code: {parts[2]}", "Parsing Action Code");
        if (!DateTime.TryParse(parts[0], out timestamp)) return null;

        string beaconCode = parts[1].Trim();
        string actionCode = parts[2].Trim();

        if (line.Contains("}")) { _processingEnded = true; 
        _serialPort.WriteLine($"{pCode} CLDATA");
        }


        return new Event
        {
            Id = Guid.NewGuid().ToString(),
            PortalId = pCode,
            UserId = "lucasvalente",
            Timestamp = timestamp,
            Direction = GetActionFromCode(actionCode),
            Picture = string.Empty,
            VesselId = "vessel1",
            Action = GetActionFromCode(actionCode),
            Manual = false,
            Justification = beaconCode,
            Status = "sync_pending"
        };
    }

    private int GetActionFromCode(string code)
    {   
        switch (code) // Assuming ActionEnum is defined
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

    public void StopProcessing()
    {
        _cancellationTokenSource.Cancel();
        if (_serialPort.IsOpen)
        {
            _serialPort.Close();
        }
        MessageBox.Show("Serial processing stopped.", "Information");
    }

    public void Dispose()
    {
        if (_serialPort != null)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
            _serialPort.Dispose();
        }

        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Dispose();
        }
        MessageBox.Show("Serial processing disposed.", "Information");
    }
}
