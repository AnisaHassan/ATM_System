using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class DataCalcEventArgs: EventArgs 
    {
        public List<Plane> DataList { get; }
     
        public DataCalcEventArgs(List<Plane> dataList)
        {
            this.DataList = dataList;
            
        }

    }
}
