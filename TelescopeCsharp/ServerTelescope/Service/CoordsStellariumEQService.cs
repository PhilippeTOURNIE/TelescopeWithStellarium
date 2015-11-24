using ServerTelescope.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTelescope.Service
{
    public  class CoordsStellariumEQService
    {
        private static CoordsStellariumEQService _Singleton=null;
        public static CoordsStellariumEQService Service
        {
            get
            {
                if (_Singleton == null)
                    _Singleton= new CoordsStellariumEQService();
                return _Singleton;
            }
        }

        #region Field & Property

        #region Plugin Server
        HMS _CurrentAscensionH;

        public HMS CurrentAscensionH
        {
            get { return _CurrentAscensionH; }
            set { _CurrentAscensionH = value; }
        }
        DMS _CurrentAscensionDeg;

        public DMS CurrentAscensionDeg
        {
            get { return _CurrentAscensionDeg; }
            set { _CurrentAscensionDeg = value; }
        }
        DMS _CurrentDeclinaisonDeg;

        public DMS CurrentDeclinaisonDeg
        {
            get { return _CurrentDeclinaisonDeg; }
            set { _CurrentDeclinaisonDeg = value; }
        }

        HMS _GotoAscensionH;

        public HMS GotoAscensionH
        {
            get { return _GotoAscensionH; }
            set { _GotoAscensionH = value; }
        }
        DMS _GotoAscensionDeg;

        public DMS GotoAscensionDeg
        {
            get { return _GotoAscensionDeg; }
            set { _GotoAscensionDeg = value; }
        }
        DMS _GotoDeclinaisonDeg;

        public DMS GotoDeclinaisonDeg
        {
            get { return _GotoDeclinaisonDeg; }
            set { _GotoDeclinaisonDeg = value; }
        }
        #endregion

        #region Stellarium
        uint _Current_ra_Stellarium;
        public uint Current_ra_Stellarium
        {
            get { return _Current_ra_Stellarium; }
            set { _Current_ra_Stellarium = value; }
        }
        int _Current_dec_Stellarium;

        public int Current_dec_Stellarium
        {
            get { return _Current_dec_Stellarium; }
            set { _Current_dec_Stellarium = value; }
        }
        long _Current_Time_Stellarium;

        public long Current_Time_Stellarium
        {
            get { return _Current_Time_Stellarium; }
            set { _Current_Time_Stellarium = value; }
        }

        uint _Goto_ra_Stellarium;

        public uint Goto_ra_Stellarium
        {
            get { return _Goto_ra_Stellarium; }
            set { _Goto_ra_Stellarium = value; }
        }
        int _Goto_dec_Stellarium;

        public int Goto_dec_Stellarium
        {
            get { return _Goto_dec_Stellarium; }
            set { _Goto_dec_Stellarium = value; }
        }
        long _Goto_Time_Stellarium;

        public long Goto_Time_Stellarium
        {
            get { return _Goto_Time_Stellarium; }
            set { _Goto_Time_Stellarium = value; }
        }
        #endregion

        #endregion

        #region Convert : plugin server <-> stellarium

        /// <summary>
        /// Conversion des données reçues de stellarium vers le plugin c# au format Equatorial
        /// </summary>
        /// <param name="ra"></param>
        /// <param name="dec"></param>
        /// <param name="mtime"></param>
        public void StellariumToServer(uint ra, int dec, long mtime)
        {
            //// Transforms the values obtained from "Stellarium Telescope Protocol", to a list with each value in string format
            // ("HhMmSSs", "DºM'S''", "HhMmSs")
            //
            // \param ra Right ascension
            // \param dec Declination
            // \param mtime Timestamp in microseconds
            // \return List with (Right ascension, declination, time) => ("HhMmSSs", "DºM'S''", "HhMmSs")

            _Goto_ra_Stellarium = ra;
            _Goto_dec_Stellarium = dec;
            _Goto_Time_Stellarium = mtime;

            double ra_h = ra * 12.0 / 2147483648;
            double dec_d = dec * 90.0 / 1073741824;
            double time_s = Math.Floor((double)(mtime / 1000000));

            GotoDeclinaisonDeg = grad_min_sec(dec_d);
            GotoAscensionDeg = grad_min_sec(ra_h);
            GotoAscensionH = hour_min_sec(ra_h);
        }
        /// <summary>
        /// Transforms coordinates from radians to the "Stellarium Telescope Protocol" format      
        /// \param ra Right ascension (float)
        /// \param dec Declination (float)
        /// \return List with (Right ascension, Declination) in the "Stellarium Telescope Protocol" format
        /// </summary>

        void ServerToStellarium()
        {
            double ra_S = ConvertDeg(_CurrentAscensionDeg);
            double dec_S = ConvertDeg(_CurrentDeclinaisonDeg);

            _Current_ra_Stellarium = (uint)(ra_S * 2147483648 / 12.0);
            _Current_dec_Stellarium = (int)(dec_S * 1073741824 / 90.0);
            //_Current_Time_Stellarium = Math.Floor((double)(mtime / 1000000));

        }

        #endregion
        #region Convert TCP Message Stellarium
        /*
        ---------------------
        client->server:
        ---------------------
        MessageGoto (type =0)
        LENGTH (2 bytes,integer): length of the message
        TYPE   (2 bytes,integer): 0
        TIME   (8 bytes,integer): current time on the client computer in microseconds
                        since 1970.01.01 UT. Currently unused.
        RA     (4 bytes,unsigned integer): right ascension of the telescope (J2000)
                 a value of 0x100000000 = 0x0 means 24h=0h,
                 a value of 0x80000000 means 12h
        DEC    (4 bytes,signed integer): declination of the telescope (J2000)
                 a value of -0x40000000 means -90degrees,
                 a value of 0x0 means 0degrees,
                 a value of 0x40000000 means 90degrees
        */
        public  void ClientServerByte(byte[] receive)
        {
            byte[] blenght = new byte[2] { receive[0], receive[1] };
            int lenght = BitConverter.ToInt16(blenght, 0);
            byte[] btype = new byte[2] { receive[2], receive[3] };
            int type = BitConverter.ToInt16(btype, 0);
            byte[] btime = new byte[8] {  receive[4], receive[5], receive[6], receive[7] ,receive[8],
                receive[9], receive[10], receive[11] };
            int time = BitConverter.ToInt32(btime, 0);
            byte[] bRA = new byte[4] { receive[12], receive[13], receive[14], receive[15] };
            uint ra = BitConverter.ToUInt32(bRA, 0);
            byte[] bDEC = new byte[4] { receive[16], receive[17], receive[18], receive[19] };
            int dec = BitConverter.ToInt32(bDEC, 0);

            StellariumToServer(ra, dec, time);
        }
        /*
      -----------------------
      server->client:
      -----------------------
      MessageCurrentPosition (type = 0):

      LENGTH (2 bytes,integer): length of the message
      TYPE   (2 bytes,integer): 0
      TIME   (8 bytes,integer): current time on the server computer in microseconds
               since 1970.01.01 UT. Currently unused.
      RA     (4 bytes,unsigned integer): right ascension of the telescope (J2000)
               a value of 0x100000000 = 0x0 means 24h=0h,
               a value of 0x80000000 means 12h
      DEC    (4 bytes,signed integer): declination of the telescope (J2000)
               a value of -0x40000000 means -90degrees,
               a value of 0x0 means 0degrees,
               a value of 0x40000000 means 90degrees
      STATUS (4 bytes,signed integer): status of the telescope, currently unused.
               status=0 means ok, status<0 means some error
      */
        public byte[] ServerClientByte()
        {
            ServerToStellarium();
            
            byte[] msg=new byte[24];
            byte[] blenght = BitConverter.GetBytes((Int16)24);
            byte[] btype = BitConverter.GetBytes((Int16)0);
            byte[] btime = new byte[8];
            byte[] bdec = BitConverter.GetBytes(Current_dec_Stellarium);
            byte[] bra = BitConverter.GetBytes(Current_ra_Stellarium);
            byte[] bstatus = new byte[4];
            //merge all
            System.Buffer.BlockCopy(blenght, 0, msg, 0, 2);
            System.Buffer.BlockCopy(btype, 0, msg, 2, 2);
            //System.Buffer.BlockCopy(btime, 0, msg, 4, 8); not use
            System.Buffer.BlockCopy(bra, 0, msg, 12, 4);
            System.Buffer.BlockCopy(bdec, 0, msg, 16, 4);
            System.Buffer.BlockCopy(bstatus, 0, msg, 20, 4);
            return msg;
                        
        }
        #endregion
        #region Convert data

        // \param degs Degrees in float format
        // \return List with (degrees, minutes, seconds)
        DMS grad_min_sec(double degs)
        {
            //Avoiding operations with negative values

            bool to_neg = false;
            if (degs < 0)
            {
                degs = Math.Abs((double)degs);
                to_neg = true;
            }
            double d = Math.Floor((double)degs);
            double degs_m = (degs - d) * 60.0;
            double m = Math.Floor(degs_m);

            double s = (degs_m - m) * 60.0;

            //Avoiding the .60 values
            if (s >= 59.99)
            {
                s = 0;
                m += 1;
            }
            if (m >= 60.0)
            {

                m = 60.0 - m;
                d += 1;
            }
            if (to_neg)
            {
                d = -d;
            }
            DMS dms = new DMS();
            dms.Degre = (int)d;
            dms.Minute = (int)m;
            dms.Seconde = s;
            return dms;
        }


        //// From hours in float format, to a list with number of hours, minutes and seconds
        //
        // \param hours Hours in float format
        // \return List with (hours, minutes, seconds)
        HMS hour_min_sec(double hours)
        {
            double h = 0;
            double m = 0;
            double s = 0;
            h = Math.Floor((double)hours);

            double hours_m = (hours - h) * 60.0;
            m = Math.Floor(hours_m);

            s = (hours_m - m) * 60.0;

            if (s >= 59.99)
            {

                s = 0;
                m += 1;
            }
            if (m >= 60)
            {
                m = 60 - m;
                h += 1;
            }
            HMS dms = new HMS();
            dms.Heure = (int)h;
            dms.Minute = (int)m;
            dms.Seconde = s;
            return dms;
        }
        double ConvertDeg(DMS dms)
        {
            double deg = dms.Degre;
            deg = Math.Abs(deg);
            deg += dms.Minute / 60.0;
            deg += dms.Seconde / 3600.0;
            if (dms.Degre < 0)
                deg = -deg;
            return deg;
        }
        #endregion
    }
}
