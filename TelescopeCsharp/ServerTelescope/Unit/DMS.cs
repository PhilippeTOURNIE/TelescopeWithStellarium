using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTelescope.Unit
{
    /// <summary>
    /// Degre Minute Seconde
    /// </summary>
    public class DMS
    {
        int _Degre;

        public int Degre
        {
            get { return _Degre; }
            set { _Degre = value; }
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
