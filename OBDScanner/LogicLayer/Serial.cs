﻿using System.IO;
using System.IO.Ports;

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
        public void InitSerial(string name = "COM8", int baud = 38400,
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
        public string ParseSerialResponse(string response)
        {
            return response;
        }
        public string ReadSerial()
        {
            string response = port.ReadLine();
            return ParseSerialResponse(response);
        }
        public void WriteSerial(string command)
        {
            port.Write(command + '\r');
        }

        public void CloseSerial()
        {
            port.Close();
        }
        public override string ToString()
        {
            return "Połączono z portem: " + port.PortName + ". Baud rate: " + port.BaudRate.ToString();
        }
    }
}
