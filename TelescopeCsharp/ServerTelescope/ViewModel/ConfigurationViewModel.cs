using GalaSoft.MvvmLight.Command;
using ServerTelescope.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerTelescope.ViewModel
{
    public class ConfigurationViewModel : INotifyPropertyChanged,IDataErrorInfo
    {

        private Service.SerialService _Serial;

        RelayCommand _SendRefresh;
        public RelayCommand SendRefresh
        {
            get { return _SendRefresh; }
            set { _SendRefresh = value; }
        }
        int _IdPort = 27000;

        public int IdPort
        {
            get { return _IdPort; }
            set
            {
                _IdPort = value;
                RaisePropertyChanged("IdPort");
            }
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

        RelayCommand _SaveCommand;
        public RelayCommand SaveCommand
        {
            get { return _SaveCommand; }
            set { _SaveCommand = value; }
        }


        public ConfigurationViewModel()
        {
            _SaveCommand = new RelayCommand(DoSave);
            _SendRefresh = new RelayCommand(DoRefresh);
            _ComSource = System.IO.Ports.SerialPort.GetPortNames().ToList();
            RaisePropertyChanged("ComSource");

            IdPort = Settings.Default.IdPort;
            ComSelected = _ComSource.FirstOrDefault(e => e == Settings.Default.SerialName);

        }
        private void DoSave()
        {
            Settings.Default.SerialName = ComSelected;
            Settings.Default.IdPort = IdPort;
            Settings.Default.Save();
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

        #region validation Error
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get {
                string error = string.Empty;
                switch (columnName)
                {
                    case "IdPort":
                        if (IdPort < 7000 || IdPort > 27015)
                        {
                            error = "IdPort [7000-27015]";
                        }
                        break;
                    default:
                        break;
                }
                return error;
            }
        }
        #endregion
    }
}
