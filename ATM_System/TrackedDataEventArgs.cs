using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class TrackedDataEventArgs :EventArgs
    {
        public Plane TrackedInfo;

        public TrackedDataEventArgs(Plane trackedInfo)
        {
            this.TrackedInfo = trackedInfo;
        }
    }
}
