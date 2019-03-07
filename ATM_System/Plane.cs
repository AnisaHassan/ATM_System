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
        public string _time { get; set; }
        public string _compassCourse { get; set; }
        public int _velocity { get; set; }

        public Plane(string tag, int xcoor, int ycoor, int altitude, string time, string compassCourse, int velocity)
        {
            _tag = tag;
            _xcoor = xcoor;
            _ycoor = ycoor;
            _altitude = altitude;
            _time = DateTime.Now.ToString(time);
            _velocity = velocity;
            _compassCourse = compassCourse;

        }
    }
}
