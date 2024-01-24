using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace DockCheckWindows.Services
{
    public class SerialPortService
    {
        private static SerialPort _serialPort = new SerialPort("COM5", 115200);
        private static object _lock = new object();

        public static void OpenPort()
        {
            lock (_lock)
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
            }
        }

        public static void ClosePort()
        {
            lock (_lock)
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
            }
        }

        public static void WriteToPort(string data)
        {
            lock (_lock)
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.WriteLine(data);
                }
            }
        }

        public static string ReadFromPort(int timeout)
        {
            lock (_lock)
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.ReadTimeout = timeout;
                    try
                    {
                        return _serialPort.ReadLine();
                    }
                    catch (TimeoutException)
                    {
                        return null;
                    }
                }
                return null;
            }
        }

        public static async Task<string> ReadLineWithTimeout(int timeout)
        {
            return await Task.Run(() =>
            {
                lock (_lock)
                {
                    if (_serialPort.IsOpen)
                    {
                        _serialPort.ReadTimeout = timeout;
                        try
                        {
                            return _serialPort.ReadLine();
                        }
                        catch (TimeoutException)
                        {
                            return null;
                        }
                    }
                    return null;
                }
            });
        }

        public static bool IsPortOpen
        {
            get
            {
                lock (_lock)
                {
                    return _serialPort.IsOpen;
                }
            }
        }
    }
}
