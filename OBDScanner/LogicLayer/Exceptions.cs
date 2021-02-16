using System;

namespace LogicLayer
{
    public class NoDeviceException : Exception
    {
        public NoDeviceException(string message, string port) : base(message)
        {
            Port = port;
            FullMessage = Message + Port;
        }
        public string Port { get; set; }
        private string fullMessage;

        public string FullMessage
        {
            get { return fullMessage; }
            private set { fullMessage = value; }
        }

    }
}
