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
        public class TrackInfotest
        {
            private ITrackInfo _uut;
            public List<Plane> TrackedDataInfo { get; set; }
            private ITrackReciever _fakeTrackReciever;
     


            [SetUp]
            public void SetUp()
            {
                _uut = new TrackInfo();
                _fakeTrackReciever = new TrackReciever();
            }


            [Test]
            public void correctListIsCreated()
            {
             
                Plane p = new Plane();
                p._tag = "TRE123";
                p._xcoor = 10000;
                p._ycoor = 10000;
                p._altitude = 100;
                p._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
              

                Plane p1 = new Plane();
                p1._tag = "ATR321";
                p1._xcoor = 80000;
                p1._ycoor = 90000;
                p1._altitude = 100;
                p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));

                List<Plane> planelist = new List<Plane>();
                planelist.Add(p);
                planelist.Add(p1);

                _fakeTrackReciever.TrackedDataReady += Raise.EventWith(this, new TrackedDataEventArgs(planelist));

                Assert.That(_uut.Airspace(planelist).Count, Is.EqualTo(2));


            }



            [TestCase(10000, 10000, 1)]
            [TestCase(10001, 1000, 0)]
            [TestCase(10000, 10001, 1)]
            [TestCase(10001, 10001, 1)]
            [TestCase(9999, 10000, 0)]
            [TestCase(10000, 9999, 0)]
            public void check_plane_isinAirSpace(int x_coor, int y_coor, int count)
            {
                TrackedDataInfo = new List<Plane>();
                Plane p = new Plane();
                p._xcoor = x_coor;
                p._ycoor = y_coor;

                TrackedDataInfo.Add(p);

                _uut.Airspace(TrackedDataInfo);


                Assert.That(_uut.PlanesInAirSpaceList.Count, Is.EqualTo(count));

            }

           
        }
    }
}

