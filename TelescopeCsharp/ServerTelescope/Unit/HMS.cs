using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTelescope.Unit
{
    /// <summary>
    /// Heure Minute Seconde
    /// </summary>
    public class HMS
    {
        int _Heure;

        public int Heure
        {
            get { return _Heure; }
            set { _Heure = value; }
        }
        int _Minute;

        public int Minute
        {
            get { return _Minute; }
            set { _Minute = value; }
        }
        double _Seconde;

        public double Seconde
        {
            get { return _Seconde; }
            set { _Seconde = value; }
        }
    }
}
