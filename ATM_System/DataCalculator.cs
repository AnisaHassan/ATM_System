using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class DataCalculator : IDataCalculator
    {
        public void CalculateVelocity(Plane planeOld, Plane planeNew)
        {
            double distance = Math.Sqrt(Math.Pow(planeOld._xcoor - planeNew._xcoor, 2) +
                                     Math.Pow(planeOld._ycoor - planeNew._ycoor, 2) +
                                     Math.Pow(planeOld._altitude - planeNew._altitude, 2));
            double time = (planeOld._time - planeNew._time).TotalSeconds;

            planeNew._velocity = (distance / time);
        }

        public void CalculateCourse(Plane planeOld, Plane planeNew)
        {
            double slope = (planeOld._ycoor - planeNew._ycoor) / (planeOld._xcoor - planeNew._xcoor);

            planeNew._compassCourse = 90 - ((Math.Atan(slope)*1800)/Math.PI);

        }
    }
}
