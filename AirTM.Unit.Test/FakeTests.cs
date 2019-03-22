using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System;
using TransponderReceiver;
using NUnit.Framework;
using NSubstitute;

namespace AirTM.Unit.Test
{
    class FakeTests
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private DataCalculator uut;


        [SetUp]
        public void SetUp()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            uut = new DataCalculator(new TrackInfo());
        }

         [Test]
        public void AirSpaceOnlyFlightsWithinTheSpace()
        {
            List<string> testData = new List<string>();
            testData.Add("ATR423;85045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85001;12000;20151006213456789");
            testData.Add("XYZ987;85000;75654;4000;20151006213456789");
            testData.Add("XYZ987;70000;80654;4000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(uut.nyliste.Count.Equals(1));
        }
        [Test]
        public void AirspaceCorrectTag()
        {
            List<string> testData = new List<string>();
            testData.Add("XYZ987;85000;75654;4000;20151006213456789");

           
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(uut.nyliste[0]._tag.Equals("XYZ987"));
        }
        [Test]
        public void AirspaceCorrectXCoordinate()
        {
            List<string> testData = new List<string>();
            testData.Add("XYZ987;85000;75654;4000;20151006213456789");

           
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(uut.nyliste[0]._xcoor.Equals(85000));
        }

        [Test]
        public void AirspaceCorrectYCoordinate()
        {
            List<string> testData = new List<string>();
            testData.Add("XYZ987;85000;75654;4000;20151006213456789");

            
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(uut.nyliste[0]._ycoor.Equals(75654));
        }
        [Test]
        public void AirspaceCorrectAltitude()
        {
            List<string> testData = new List<string>();
            testData.Add("XYZ987;85000;75654;4000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(uut.nyliste[0]._altitude.Equals(4000));
        }

        [Test]
        public void AirspaceCorrectTimestamp()
        {
            List<string> testData = new List<string>();
            testData.Add("XYZ987;85000;75654;4000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(uut.nyliste[0]._time.Equals(new DateTime(2015, 10, 06, 21, 34, 56, 789)));
        }

        
    }


}
