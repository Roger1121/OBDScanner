using System.IO.Ports;

namespace LogicLayer
{
    class Serial
    {
        //programm will work with one OBD2 interface at once
        SerialPort port;
        public void initSerial(string name = "OBD", int baud = 38400,
                               Parity parity = Parity.None, int dataBits = 8,
                               StopBits stopBits = StopBits.One)
        {
            port = new SerialPort(name, baud, parity, dataBits, stopBits);
        }
        public string parseSerialResponse(string response)
        {
            return response;
        }
        public string readSerial()
        {
            string response=null;
            return parseSerialResponse(response);
        }
        public void writeSerial(string command)
        {

        }
    }
}
