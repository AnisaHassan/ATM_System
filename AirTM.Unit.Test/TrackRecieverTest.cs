using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiver;
using ATM_System;
using NSubstitute;



namespace AirTM.Unit.Test
{
    [TestFixture]
    public class TrackRecieverTest
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private ITrackInfo _fakeTrackInfo;
        private TrackReciever _uut;
        private List<string> stringList;
        private List<Plane> planeList;

        [SetUp]
        public void SetUp()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _fakeTrackInfo = Substitute.For<ITrackInfo>();
            _uut = new TrackReciever(_fakeTransponderReceiver);
                        

        }

        [Test]
        public void Test_Input_correct()
        {
            List<Plane> planeList = null;
            List<string> stringlist = new List<string>();
            string s = "ATR423;39045;12932;14000;20151006213456789";
            stringlist.Add(s);

            _uut.TrackedDataReady += (o, e) => { planeList = e.TrackedInfo; }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringlist));

            DateTime date = new DateTime(2015, 10, 06, 21, 34, 56, 789);

            //Assert that result and expected are equal
            Assert.That(planeList[0]._tag, Is.EqualTo("ATR423"));
            Assert.AreEqual(planeList[0]._xcoor, 39045);
            Assert.AreEqual(planeList[0]._ycoor, 12932);
            Assert.AreEqual(planeList[0]._altitude, 14000);
            Assert.AreEqual(planeList[0]._time, date);
            Assert.AreEqual(planeList[0]._compassCourse, 0);
            Assert.AreEqual(planeList[0]._velocity, 0);
        }

        [Test]
        public void TrackReciver_recived_correct_from_faketransponderreciver()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");
            stringList.Add("ABC121;12305;87501;13000;20151006213456779");
            stringList.Add("DEF182;46000;87654;12000;20151006213456769");
            stringList.Add("XKJ967;90239;99876;11000;20151006213456759");

            _fakeTransponderReceiver.TransponderDataReady 
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));
          Assert.That(_uut.TrackedInfo(stringList).Count, Is.EqualTo(4));


        }


        //Test af metoden TrackedInfo
        [Test]
        public void planeList_tag_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");
           
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._tag, Is.EqualTo("ATR423"));
        }

        [Test]
        public void planeList_xcoor_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);
            Assert.That(planeList[0]._xcoor, Is.EqualTo(39045));
        }
        [Test]
        public void planeList_ycoor_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._ycoor, Is.EqualTo(12932));
        }

        [Test]
        public void planeList_alitude_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._altitude, Is.EqualTo(14000));
        }


        [Test]
        public void planeList_Timestamp_Year_isCorrect()
        {

            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._time.Year, Is.EqualTo(2015));
        }
        [Test]
        public void planeList_Timestamp_Month_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._time.Month, Is.EqualTo(10));
        }

        [Test]
        public void planeList_Timestamp_Day_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._time.Day, Is.EqualTo(06));
        }

        [Test]
        public void planeList_Timestamp_Hour_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._time.Hour, Is.EqualTo(21));
        }

        [Test]
        public void planeList_Timestamp_Minutes_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);


            Assert.That(planeList[0]._time.Minute, Is.EqualTo(34));
        }

        [Test]
        public void planeList_Timestamp_Second_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._time.Second, Is.EqualTo(56));
        }

        [Test]
        public void planeList_Timestamp_Millisecond_isCorrect()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));

            planeList = _uut.TrackedInfo(stringList);

            Assert.That(planeList[0]._time.Millisecond, Is.EqualTo(789));
        }
        
    }
}
