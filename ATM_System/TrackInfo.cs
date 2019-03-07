using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class TrackInfo
    {
        private string _tag { get; set; }
        private int _xcoor { get; set; }
        private int _ycoor { get; set; }
        private int _altitude { get; set; }
        private DateTime _date; 

        public TrackInfo (string tag, int xcoor, int ycoor, int altitude, DateTime date)
        {
            _tag = tag;
            _xcoor = xcoor;
            _ycoor = ycoor;
            _altitude = altitude;
            _date = date; 
        }

    }

}
