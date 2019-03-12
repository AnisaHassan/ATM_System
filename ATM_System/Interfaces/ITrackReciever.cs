using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
   public interface ITrackReciever
    {
        //event EventHandler<TrackedDataEventArgs> TrackedDataReady;
        List<Plane> TrackedInfo(List<string> planeliste);


    }
}
