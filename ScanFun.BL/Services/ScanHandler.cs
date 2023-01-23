using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace ScanFun.BL.Services
{
    public class ScanHandler
    {
        public static Action<string> Action { get; private set; }
        private readonly SerialPort _serialPort;

        public ScanHandler(Action<string> action)
        {
            Action = action;

            _serialPort = new SerialPort("COM3");

            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataBits = 8;
            _serialPort.Handshake = Handshake.None;
            _serialPort.RtsEnable = true;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            _serialPort.Open();
            _serialPort.Close();
        }

        public void StopScanHandle()
        {
            _serialPort.Close();
        }

        public void StartScanHandle()
        {
            _serialPort.Open();
        }

        private static void DataReceivedHandler(
                            object sender,
                            SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            new Thread(() =>
            {
                Action(indata);
            }).Start();
        }
    }
}
