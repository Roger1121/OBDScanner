﻿using System.IO.Ports;

namespace LogicLayer
{
    public class Serial
    {
        public Serial(string name = "COM8", int baud = 38400,
                      Parity parity = Parity.None, int dataBits = 8,
                      StopBits stopBits = StopBits.One)
        {
            InitSerial(name, baud, parity, dataBits, stopBits);
        }

        //programm will work with one OBD2 interface at once
        private SerialPort port;
        public void InitSerial(string name = "COM8", int baud = 38400,
                               Parity parity = Parity.None, int dataBits = 8,
                               StopBits stopBits = StopBits.One)
        {
            port = new SerialPort(name, baud, parity, dataBits, stopBits);
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
            port.Open();
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
