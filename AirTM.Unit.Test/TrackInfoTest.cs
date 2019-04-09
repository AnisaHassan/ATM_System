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
    public class TrackInfoTest
    {
        [TestFixture]
        public class TrackInfotest
        {
            private ITrackInfo _uut;
            private ITrackReciever _fakeTrackReciever;

            [SetUp]
            public void SetUp()
            {
                _fakeTrackReciever = Substitute.For<ITrackReciever>();
                _uut = new TrackInfo(_fakeTrackReciever);
            }

            [Test]
            public void Test_Input_correct()
            {
                List<Plane> planelist = null;
                List<Plane> pl = new List<Plane>();
                Plane p = new Plane();
                p._tag = "TRE123";
                p._xcoor = 10000;
                p._ycoor = 10000;
                p._altitude = 100;
                DateTime date = new DateTime(2015, 10, 06, 21, 34, 56, 798);
                p._time = (DateTime.ParseExact("20151006213456798", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
                
                pl.Add(p);

                _uut.AirspaceDataReady += (o, e) => { planelist = e.DataList; }; //Simulates formatted data ready event
                _fakeTrackReciever.TrackedDataReady += Raise.EventWith(this, new TrackedDataEventArgs(pl));

                Assert.That(planelist[0]._tag, Is.EqualTo("TRE123"));
                Assert.That(planelist[0]._xcoor, Is.EqualTo(10000));
                Assert.That(planelist[0]._ycoor, Is.EqualTo(10000));
                Assert.That(planelist[0]._altitude, Is.EqualTo(100));
                Assert.That(planelist[0]._time, Is.EqualTo(date));
                Assert.That(planelist[0]._compassCourse, Is.EqualTo(0));
                Assert.That(planelist[0]._velocity, Is.EqualTo(0));
            }

          
            [TestCase(10000, 10000, 1)]
            [TestCase(10001, 1000, 0)]
            [TestCase(10000, 10001, 1)]
            [TestCase(10001, 10001, 1)]
            [TestCase(9999, 10000, 0)]
            [TestCase(10000, 9999, 0)]
            public void check_plane_isinAirSpace(int x_coor, int y_coor, int count)
            {
               List<Plane> list = new List<Plane>();
                Plane p = new Plane();
                p._xcoor = x_coor;
                p._ycoor = y_coor;

                list.Add(p);

                _uut.Airspace(list);
                
              Assert.That(_uut.PlanesInAirSpaceList.Count, Is.EqualTo(count));

            }

           
        }
    }
}

