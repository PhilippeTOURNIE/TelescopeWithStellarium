using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTelescope.ViewModel
{


    public class TestSerialViewModel : INotifyPropertyChanged
    {
        #region field
        System.Windows.Threading.Dispatcher thisdispatcher;
        delegate void SetTextCallback(string text);
        private Service.SerialService _Serial;
        #endregion
        #region properties

        private string _TextSend = string.Empty;

        public string TextSend
        {
            get { return _TextSend; }
            set { _TextSend = value;
            RaisePropertyChanged("TextSend");
            }
        }

        RelayCommand _SendRefresh;
        public RelayCommand SendRefresh
        {
            get { return _SendRefresh; }
            set { _SendRefresh = value; }
        }

        RelayCommand _SendCommand;
        public RelayCommand SendCommand
        {
            get { return _SendCommand; }
            set { _SendCommand = value; }
        }

        private List<string> _ComSource;
        public List<string> ComSource
        {
            get { return _ComSource; }
            set
            {
                _ComSource = value;
                RaisePropertyChanged("ComSource");
            }
        }
        private string _ComSelected = "";

        public string ComSelected
        {
            get { return _ComSelected; }
            set
            {

                //Changement de port on ferme le précedent
                if (value != _ComSelected && _Serial != null)
                {
                    _Serial.Close();
                    _Serial = null;
                }
                _ComSelected = value;
                RaisePropertyChanged("ComSelected");
            }
        }
        private ObservableCollection<string> _RecieveDatas = new ObservableCollection<string>();
        public ObservableCollection<string> RecieveDatas
        {
            get { return _RecieveDatas; }
            set { _RecieveDatas = value; }
        }

        #endregion

        public TestSerialViewModel()
        {
            thisdispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            _SendCommand = new RelayCommand(DoSend);
            _SendRefresh = new RelayCommand(DoRefresh);

            _ComSource = System.IO.Ports.SerialPort.GetPortNames().ToList();
            RaisePropertyChanged("ComSource");

        }
        void Port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {           
            string inputData=_Serial.Port.ReadLine();            
            thisdispatcher.BeginInvoke(new SetTextCallback(SetText), new object[] { inputData });
        }
        private void SetText(string text)
        {
            RecieveDatas.Add(text);
            RaisePropertyChanged("RecieveDatas");
        }
        private void DoSend()
        {
            if (String.IsNullOrWhiteSpace(ComSelected)) return;
            if (_Serial == null)
            {
                _Serial = new Service.SerialService(ComSelected);
                _Serial.Port.DataReceived += Port_DataReceived;
            }

            _Serial.SendString(TextSend);

        }
        private void DoRefresh()
        {
            ComSource = ServerTelescope.Service.SerialService.getListSerialPort();
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
        #endregion

    }
}
