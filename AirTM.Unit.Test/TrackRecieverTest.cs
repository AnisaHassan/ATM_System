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
        private ITrackReciever _uut;
        private List<string> stringList;
        private TrackedDataEventArgs output;
        [SetUp]
        public void SetUp()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new TrackReciever(_fakeTransponderReceiver);

            _uut.TrackedDataReady += (o, a) => { output = a; };
        }

        [Test]
        public void Test_Input_correct()
        {
            stringList = new List<string>();
            stringList.Add("ATR423;39045;12932;14000;20151006213456789");
            DateTime date = new DateTime(2015, 10, 06, 21, 34, 56, 789);
           
            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(stringList));
            
            //Assert that result and expected are equal
            Assert.That(output.TrackedInfo[0]._tag, Is.EqualTo("ATR423"));
            Assert.That(output.TrackedInfo[0]._xcoor, Is.EqualTo(39045));
            Assert.That(output.TrackedInfo[0]._ycoor, Is.EqualTo(12932));
            Assert.That(output.TrackedInfo[0]._altitude, Is.EqualTo(14000));
            Assert.That(output.TrackedInfo[0]._time, Is.EqualTo(date));
            Assert.That(output.TrackedInfo[0]._compassCourse, Is.EqualTo(0));
            Assert.That(output.TrackedInfo[0]._velocity, Is.EqualTo(0));
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

            Assert.That(output.TrackedInfo.Count, Is.EqualTo(4));
        }
     
    }
}
