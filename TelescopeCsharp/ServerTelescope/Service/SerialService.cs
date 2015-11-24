using ServerTelescope.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTelescope.Service
{
    public class SerialService
    {
        static bool _ClientConnected = false;
        public static bool ClientConnected { get { return _ClientConnected && Status; } }
        public static bool Status = false;
        public static string ErrorMessage = string.Empty;
        private static SerialService _Singleton = null;
        public static SerialService Start()
        {
            if (_Singleton == null)
                _Singleton = new SerialService(Settings.Default.SerialName,Settings.Default.SerialBaudRate);
            return _Singleton;
        }
        public static void Stop()
        {
            _Singleton.Close();
            _Singleton = null;
            Status = false;
            ErrorMessage = string.Empty;
        }

        #region Fields
        System.IO.Ports.SerialPort _Port;
        public System.IO.Ports.SerialPort Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        #endregion


        public SerialService(string namePort)
        {
            try
            {
                _Port = new System.IO.Ports.SerialPort(namePort);
                init();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Status = false;
            }
            Status = true;
        }
        public SerialService(string namePort, int baudRate)
        {
            try
            {
                _Port = new System.IO.Ports.SerialPort(namePort, baudRate);
                init();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Status = false;
            }
            Status = true;
        }
        public SerialService(string namePort, int baudRate, System.IO.Ports.Parity parity)
        {
            try
            {
                _Port = new System.IO.Ports.SerialPort(namePort, baudRate, parity);
                init();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Status = false;
            }
            Status = true;
        }

        public static List<string> getListSerialPort()
        {
            return System.IO.Ports.SerialPort.GetPortNames().ToList();
        }


        private void init()
        {
            _Port.ErrorReceived += _Port_ErrorReceived;
            _Port.WriteTimeout = 1000; // 1 seconde
            _Port.ReadTimeout = 1000; // 1 seconde
            
            Open();
            Close();
        }

        private void Open()
        {
            if (_Port != null && _Port.IsOpen == false)
                _Port.Open();
        }
        public void Close()
        {
            if (_Port != null && _Port.IsOpen == true)
                _Port.Close();
        }

        #region send
        public void SendString(string texte)
        {
            Open();
            _Port.WriteLine(texte);

        }

        public void SendByte(Byte[] tabByte)
        {
            Open();
            _Port.Write(tabByte, 0, tabByte.Length);
        }
        #endregion

        #region Event
        void _Port_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            //TODO
        }
        #endregion


    }
}
