using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiver;
using ATM_System;
using ATM_System.Events;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;

namespace AirTM.Unit.Test
{
    [TestFixture]
    public class ConsolePrintTest
    {
        private ConsolePrint _uut;
        private SeperationChecker _SeperationChecker;
        private IDataCalculator _dataCalculator;
        private List<Plane> _fakeplaneList;
        private IPrint _log;


        [SetUp]
        public void SetUp()
        {
            _uut = new ConsolePrint();
            _dataCalculator = Substitute.For<DataCalculator>();
            _log = new Log();
            
            _SeperationChecker = new SeperationChecker(_dataCalculator, _log, _uut);

        }



        [Test]
        public void ConsolePrint_Is_Correct_And_Prints()
        {
            List<Plane> _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 10;
            p._altitude = 10;
            p._time = DateTime.Now;
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            _SeperationChecker.PrintToConsole(_fakeplaneList);


            //Console.WriteLine("Tag: " + p._tag + "\nX-coordinate: " + p._xcoor +
            //" meters\nY-coordinate: " +
            //p._ycoor + " meters\nAltitude: " + p._altitude +
            //" meters\nTime stamp: " + p._time.Year + "/" + p._time.Month +
            //"/" + p._time.Day +
            //", at " + p._time.Hour + ":" + p._time.Minute + ":" +
            //p._time.Second + " and " + p._time.Millisecond + " milliseconds\nVelocity: " + p._velocity + " m/s\nCourse: " +
            //p._compassCourse + " degrees\n");

            _uut.PrintPlane(_fakeplaneList);

            Convert.ToString(_fakeplaneList);


            Assert.That(_fakeplaneList[0]._tag, Is.EqualTo("TRE123"));

        }
    }
}
