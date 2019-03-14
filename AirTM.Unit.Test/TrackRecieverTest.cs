using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiver;
using ATM_System;



namespace AirTM.Unit.Test
{
    [TestFixture]
    public class TrackRecieverTest
    {
        private TrackReciever _uut;
        private List<string> stringList;
        private List<Plane> planeList;

        [SetUp]
        public void SetUp()
        {
            _uut = new TrackReciever();

            string plane = "ATR423;39045;12932;14000;20151006213456789";

            stringList = new List<string>();

            stringList.Add(plane);
            planeList = _uut.TrackedInfo(stringList);

        }
        //Test af metoden TrackedInfo
        [Test]
        public void planeList_tag_isCorrect()
        {
            //planeList[0] = Første linje i listen 
            Assert.That(planeList[0]._tag, Is.EqualTo("ATR423"));
        }

        [Test]
        public void planeList_xcoor_isCorrect()
        {
            Assert.That(planeList[0]._xcoor, Is.EqualTo(39045));
        }
        [Test]
        public void planeList_ycoor_isCorrect()
        {
            Assert.That(planeList[0]._ycoor, Is.EqualTo(12932));
        }

        [Test]
        public void planeList_alitude_isCorrect()
        {
            Assert.That(planeList[0]._altitude, Is.EqualTo(14000));
        }


        [Test]
        public void planeList_Timestamp_Year_isCorrect()
        {
            
            Assert.That(planeList[0]._time.Year, Is.EqualTo(2015));
        }
        [Test]
        public void planeList_Timestamp_Month_isCorrect()
        {
            
            Assert.That(planeList[0]._time.Month, Is.EqualTo(10));
        }

        [Test]
        public void planeList_Timestamp_Day_isCorrect()
        {
            
            Assert.That(planeList[0]._time.Day, Is.EqualTo(06));
        }

        [Test]
        public void planeList_Timestamp_Hour_isCorrect()
        {
            
            Assert.That(planeList[0]._time.Hour, Is.EqualTo(21));
        }

        [Test]
        public void planeList_Timestamp_Minutes_isCorrect()
        {
            
            Assert.That(planeList[0]._time.Minute, Is.EqualTo(34));
        }

        [Test]
        public void planeList_Timestamp_Second_isCorrect()
        {
            Assert.That(planeList[0]._time.Second, Is.EqualTo(56));
        }

        [Test]
        public void planeList_Timestamp_Millisecond_isCorrect()
        {
            Assert.That(planeList[0]._time.Millisecond, Is.EqualTo(789));
        }



    }
}
