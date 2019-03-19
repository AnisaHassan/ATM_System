using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System;
using NUnit.Framework;
using TransponderReceiver;


namespace AirTM.Unit.Test
{
    [TestFixture]
    public class DataCalcTest
    {
      private IDataCalculator uut;
      private List<string> stringList;
      private List<Plane> planeList;
      private Plane _track1;
      private Plane _track2;

        [SetUp]
      public void SetUp()
      {
          uut = new DataCalculator();

          _track1  = new Plane 
          {
              _tag = "BIJ515",
              _xcoor = 90000,
              _ycoor = 90000
          };

          _track2 = new Plane
          {
              _tag = "BIJ515",
              _xcoor = 10000,
              _ycoor = 10000
          };
            
      }





    }
}
