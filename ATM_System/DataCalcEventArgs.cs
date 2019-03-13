using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class DataCalcEventArgs
    {
        public List<Plane> DataList { get; }
        public DataCalcEventArgs(List<Plane> trackedInfo)
        {
            this.DataList = trackedInfo;
        }
    }
}
