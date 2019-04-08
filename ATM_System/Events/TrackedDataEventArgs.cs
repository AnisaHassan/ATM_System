using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class TrackedDataEventArgs :EventArgs
    {
        public List<Plane> TrackedInfo;
        public TrackedDataEventArgs(List<Plane> trackedInfo)
        {
            this.TrackedInfo = trackedInfo;
        }


       
    }
}
