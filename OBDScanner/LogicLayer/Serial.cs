using System.IO;
using System.IO.Ports;
using System.Text;

namespace LogicLayer
{
    public class Serial
    {
        private static Serial _instance;

        public static Serial GetInstance(string name="COM8", int baud=38400,
                      Parity parity = Parity.None, int dataBits = 8,
                      StopBits stopBits = StopBits.One)
        {
            if (_instance == null)
            {
                _instance = new Serial(name, baud, parity, dataBits, stopBits);
            }
            return _instance;
        }

        public void ClearTroubleCodes()
        {
            WriteSerial("04\r");
        }

        private Serial(string name, int baud, Parity parity,
                       int dataBits, StopBits stopBits)
        {
            try
            {
                InitSerial(name, baud, parity, dataBits, stopBits);
            }
            catch (NoDeviceException ex)
            {
                throw ex;
            }
        }

        private SerialPort port;
        private void InitSerial(string name = "COM8", int baud = 38400,
                               Parity parity = Parity.None, int dataBits = 8,
                               StopBits stopBits = StopBits.One)
        {
            try
            {
                port = new SerialPort(name, baud, parity, dataBits, stopBits)
                {
                    ReadTimeout = 1000,
                    WriteTimeout = 1000
                };
                port.Open();
            }
            catch (FileNotFoundException ex)
            {

                string port = ex.Message.Substring(21, 4);
                throw new NoDeviceException("Nie znaleziono urządzenia: ", port);
            }
        }

        public string ReadTroubleCodes()
        {
            string troubleCodes="", temp;
            WriteSerial("03\r");
            while(port.BytesToRead>0)
            {
                temp = port.ReadExisting();
                troubleCodes += ParseCode(temp);
            }
            return troubleCodes;
        }

        private string ParseCode(string temp)
        {
            string codes = "";
            byte[] asciiBytes = Encoding.ASCII.GetBytes(temp);
            int i = 0;
            while (i < asciiBytes.Length)
            {
                switch (asciiBytes[i] / 32)
                {
                    case 0:
                        codes += 'P';
                        break;
                    case 1:
                        codes += 'C';
                        break;
                    case 2:
                        codes += 'B';
                        break;
                    case 3:
                        codes += 'U';
                        break;
                }
                switch ((asciiBytes[i] % 64) / 16)
                {
                    case 0:
                        codes += '0';
                        break;
                    case 1:
                        codes += '1';
                        break;
                    case 2:
                        codes += '2';
                        break;
                    case 3:
                        codes += '3';
                        break;
                }
                switch (asciiBytes[i] % 16)
                {
                    case 10:
                        codes += 'A';
                        break;
                    case 11:
                        codes += 'B';
                        break;
                    case 12:
                        codes += 'C';
                        break;
                    case 13:
                        codes += 'D';
                        break;
                    case 14:
                        codes += 'E';
                        break;
                    case 15:
                        codes += 'F';
                        break;
                    default:
                        codes += (asciiBytes[i] % 16).ToString();
                        break;
                }
                switch (asciiBytes[i+1] / 16)
                {
                    case 10:
                        codes += 'A';
                        break;
                    case 11:
                        codes += 'B';
                        break;
                    case 12:
                        codes += 'C';
                        break;
                    case 13:
                        codes += 'D';
                        break;
                    case 14:
                        codes += 'E';
                        break;
                    case 15:
                        codes += 'F';
                        break;
                    default:
                        codes += (asciiBytes[i+1] / 16).ToString();
                        break;
                }
                switch (asciiBytes[i+1] % 16)
                {
                    case 10:
                        codes += 'A';
                        break;
                    case 11:
                        codes += 'B';
                        break;
                    case 12:
                        codes += 'C';
                        break;
                    case 13:
                        codes += 'D';
                        break;
                    case 14:
                        codes += 'E';
                        break;
                    case 15:
                        codes += 'F';
                        break;
                    default:
                        codes += (asciiBytes[i+1] % 16).ToString();
                        break;
                }
                codes += "\r\n";
            }
            return codes;
        }

        public string ReadSerial()
        {
            string response = port.ReadExisting();
            while(!(response is null || response ==""))
                response += port.ReadExisting();
            return response;
        }
        private void WriteSerial(string command)
        {
            
            port.Write(command+'\r');
        }

        public void CloseSerial()
        {
            port.Close();
        }

        public string ExecuteCommand(string consoleInput)
        {
            if(!(consoleInput is null || consoleInput==""))
                WriteSerial(consoleInput);
            return ReadSerial();
        }

        public override string ToString()
        {
            return "Połączono z portem: " + port.PortName + ". Baud rate: " + port.BaudRate.ToString();
        }
    }
}
