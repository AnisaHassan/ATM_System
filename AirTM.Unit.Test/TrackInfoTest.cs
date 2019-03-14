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
    class TrackInfoTest
    {
        [TestFixture]
        public class TrackRecieverTest
        {
            private TrackInfo _uut;
           // private List<string> stringList;
            private List<Plane> planeList;

            [SetUp]
            public void SetUp()
            {
                _uut = new TrackInfo();

                //string plane = "39045;12932";
                Plane p = new Plane();
                {
                    //ATR423; 39045; 12932; 14000; 20151006213456789
                    p._xcoor = 39045;
                    p._ycoor = 12932;
                }
                planeList = new List<Plane>();
                planeList.Add(p);

                planeList = _uut.Airspace(planeList);

            }
        }
    }
}

