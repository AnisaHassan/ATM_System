using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public interface IPrint
    {
        string _text { get; set; }
        void PrintPlane(List<Plane> planeliste);
        void PrintWarning(Plane plane1, Plane plane2);

    }
}
