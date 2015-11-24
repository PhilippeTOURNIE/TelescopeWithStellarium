using ServerTelescope.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ServerTelescope.ViewModel
{
    public class CoordonneesViewModel : INotifyPropertyChanged
    {
        public CoordonneesViewModel()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            RaisePropertyChanged("AD_H");
            RaisePropertyChanged("AD_M");
            RaisePropertyChanged("AD_S");
            RaisePropertyChanged("DEC_D");
            RaisePropertyChanged("DEC_M");
            RaisePropertyChanged("DEC_S");

            RaisePropertyChanged("GO_AD_H");
            RaisePropertyChanged("GO_AD_M");
            RaisePropertyChanged("GO_AD_S");
            RaisePropertyChanged("GO_DEC_D");
            RaisePropertyChanged("GO_DEC_M");
            RaisePropertyChanged("GO_DEC_S");
        }
        DispatcherTimer timer = new DispatcherTimer();

#region Current position
        public double AD_H
        {
            get
            {
                return CoordsStellariumEQService.Service.CurrentAscensionH.Heure;
            }
            set { }
        }
        public double AD_M
        {
            get
            {
                return CoordsStellariumEQService.Service.CurrentAscensionH.Minute;
            }
            set { }
        }
        public double AD_S
        {
            get
            {
                return Math.Round(CoordsStellariumEQService.Service.CurrentAscensionH.Seconde, 2);
            }
            set { }
        }

        public double DEC_D
        {
            get
            {
                return CoordsStellariumEQService.Service.CurrentDeclinaisonDeg.Degre;
            }
            set { }
        }
        public double DEC_M
        {
            get
            {
                return CoordsStellariumEQService.Service.CurrentDeclinaisonDeg.Minute;
            }
            set { }
        }
        public double DEC_S
        {
            get
            {
                return Math.Round(CoordsStellariumEQService.Service.CurrentDeclinaisonDeg.Seconde,2);
            }
            set { }
        }
#endregion
        #region Goto position
        public double GO_AD_H
        {
            get
            {
                return CoordsStellariumEQService.Service.GotoAscensionH.Heure;
            }
            set { }
        }
        public double GO_AD_M
        {
            get
            {
                return CoordsStellariumEQService.Service.GotoAscensionH.Minute;
            }
            set { }
        }
        public double GO_AD_S
        {
            get
            {
                return Math.Round(CoordsStellariumEQService.Service.GotoAscensionH.Seconde, 2);
            }
            set { }
        }

        public double GO_DEC_D
        {
            get
            {
                return CoordsStellariumEQService.Service.GotoDeclinaisonDeg.Degre;
            }
            set { }
        }
        public double GO_DEC_M
        {
            get
            {
                return CoordsStellariumEQService.Service.GotoDeclinaisonDeg.Minute;
            }
            set { }
        }
        public double GO_DEC_S
        {
            get
            {
                return Math.Round(CoordsStellariumEQService.Service.GotoDeclinaisonDeg.Seconde,2);
            }
            set { }
        }


        #endregion
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
