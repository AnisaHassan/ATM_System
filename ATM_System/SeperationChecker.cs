using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class SeperationChecker : ISeperationChecker
    {
        private List<Plane> _planelist;


        public SeperationChecker()
        {
            _planelist = new List<Plane>();
        }

        public void CheckDistance(List<Plane> planelist)
        {
            _planelist = planelist;

            foreach (var plane1 in _planelist)
            {
                foreach (var plane2 in _planelist)
                {
                    if (plane1._tag != plane2._tag)
                    {
                        double xdif = Math.Abs(plane1._xcoor - plane2._xcoor);
                        double ydif = Math.Abs(plane1._ycoor - plane2._ycoor);

                        double disth = Math.Sqrt(Math.Pow(xdif, 2) + Math.Pow(ydif, 2));
                        int distv = Math.Abs(plane1._altitude - plane2._altitude);

                        if (disth < 5000 && distv < 300)
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
}
