using GalaSoft.MvvmLight.Command;
using ServerTelescope.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTelescope.ViewModel
{
    public class InitPluginViewModel : INotifyPropertyChanged
    {
        #region Property
        /// <summary>
        /// State Serial communication
        /// </summary>
        public bool StatusSerial
        {
            get { return Service.SerialService.Status; }
            set
            {
                RaisePropertyChanged("StatusSerial");
            }
        }

        /// <summary>
        /// State Server Stellarium
        /// </summary>
        public bool StatusServer
        {
            get { return Service.TCPService.Instance.Status; }
            set
            {
                RaisePropertyChanged("StatusServer");
            }
        }
        
        public bool ClientConnectedServer
        {
            get { return Service.TCPService.Instance.ClientConnected; } 
            set { RaisePropertyChanged("ClientConnectedServer"); } 
        }
        public bool ClientConnectedSerial
        {
            get { return Service.SerialService.ClientConnected; }
            set
            {
                RaisePropertyChanged("ClientConnectedSerial");
            }
        }

        RelayCommand _SetInitServer;
        public RelayCommand SetInitServer
        {
            get { return _SetInitServer; }
            set { _SetInitServer = value; }
        }

        RelayCommand _StartServer;
        public RelayCommand StartServer
        {
            get { return _StartServer; }
            set { _StartServer = value; }
        }

        RelayCommand _StopServer;

        public RelayCommand StopServer
        {
            get { return _StopServer; }
            set { _StopServer = value; }
        }


        RelayCommand _StartSerialCom;

        public RelayCommand StartSerialCom
        {
            get { return _StartSerialCom; }
            set { _StartSerialCom = value; }
        }

        RelayCommand _StopSerialCom;

        public RelayCommand StopSerialCom
        {
            get { return _StopSerialCom; }
            set { _StopSerialCom = value; }
        }
        #endregion  
        public InitPluginViewModel()
        {
           
            _StopSerialCom = new RelayCommand(DoStopCom);
            _StartSerialCom = new RelayCommand(DoStartCom);
            _StopServer = new RelayCommand(DoStopServer);
            _StartServer = new RelayCommand(DoStartServer);
            _SetInitServer = new RelayCommand(DoInit);
        }


        private void DoInit()
        {
            //actual et la meme que goto
            CoordsStellariumEQService.Service.CurrentAscensionDeg = CoordsStellariumEQService.Service.GotoAscensionDeg;
            CoordsStellariumEQService.Service.CurrentDeclinaisonDeg = CoordsStellariumEQService.Service.GotoDeclinaisonDeg;
            CoordsStellariumEQService.Service.CurrentAscensionH = CoordsStellariumEQService.Service.GotoAscensionH;

            Service.TCPService.Instance.Send();
        }

        private void DoStopCom()
        {
            if (Service.SerialService.Status)
                Service.SerialService.Stop();
            RaisePropertyChanged("StatusSerial");
        }
        private void DoStartCom() 
        {
            if (!Service.SerialService.Status)
                Service.SerialService.Start();
            RaisePropertyChanged("StatusSerial");

        }
        private void DoStopServer() {
            Service.TCPService.Instance.Stop();
            RaisePropertyChanged("StatusServer");
        }
        private void DoStartServer() {
            Service.TCPService.Instance.Start();
            RaisePropertyChanged("StatusServer");
        }


        #region Notification
        private void RaisePropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Property

    }
}
