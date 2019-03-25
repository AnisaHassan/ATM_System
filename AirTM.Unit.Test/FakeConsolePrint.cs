using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System;

namespace AirTM.Unit.Test
{
   public class FakeConsolePrint: IPrint
   {
       public bool WasConsolePrintCalled = false;
       public bool WasWarningCalled = false;

        public void PrintPlane(List<Plane> planeliste)
        {
            WasConsolePrintCalled = true;
        }

        public void PrintWarning(Plane plane1, Plane plane2)
        {
            WasWarningCalled = true;
        }
    }
}
