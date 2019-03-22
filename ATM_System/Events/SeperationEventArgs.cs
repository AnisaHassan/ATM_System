using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System.Events
{
    public class SeperationEventArgs : EventArgs
    {
        public List<Plane> CalcedInfo { get; }

        public SeperationEventArgs(List<Plane> calcedInfo)
        {
            this.CalcedInfo = calcedInfo;
        }
    }
}
