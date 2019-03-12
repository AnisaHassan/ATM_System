using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class Plane
    {
        public string _tag { get; set; }
        public int _xcoor { get; set; }
        public int _ycoor { get; set; }
        public int _altitude { get; set; }
        public DateTime _time { get; set; }
        public double _compassCourse { get; set; }
        public double _velocity { get; set; }

        public Plane(string tag, int xcoor, int ycoor, int altitude, DateTime time, double compassCourse, double velocity)
        {
            _tag = tag;
            _xcoor = xcoor;
            _ycoor = ycoor;
            _altitude = altitude;
            _time = time;
            _velocity = velocity;
            _compassCourse = compassCourse;

        }
    }
}
