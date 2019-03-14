using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;

namespace AirTM.Unit.Test
{
    class TrackInfoTest
    {
        [TestFixture]
        public class TrackRecieverTest
        {
            private ITrackInfo _uut;

            [SetUp]
            public void SetUp()
            {
                _uut = new TrackInfo();
                
            }


            [TestCase(10000, 10000, 1)]
            [TestCase(10001, 1000, 1)]
            [TestCase(10000, 10001, 1)]
            //[TestCase(10000, 9999, 0)]
            //[TestCase(9999, 10000, 0)]
            //[TestCase(9999, 9999, 0)]
            //[TestCase(10001, 9999, 0)]
            //[TestCase(9999, 10001, 0)]
            public void plane_is_inAirSpace(int x_coor, int y_coor, int count)
            {
                List<Plane> planelist = new List<Plane>();
                Plane p = new Plane();
                p._xcoor = x_coor;
                p._ycoor = y_coor;

                planelist.Add(p);

                _uut.Airspace(planelist);


                Assert.That(_uut.PlanesInAirSpaceList.Count, Is.EqualTo(count));

            }

        }
    }
}

