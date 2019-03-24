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


namespace AirTM.Unit.Test
{
    [TestFixture]
    public class SeperationCheckerTest
    {
        private ConsolePrint _fakeConsolePrint;
        private SeperationChecker _uut;
        private IPrint _fakeLogPrint;
        private List<Plane> _fakeplaneList;
        private IDataCalculator _fakedataCalculator;


        [SetUp] 
        public void SetUp()
        {
            _fakeConsolePrint = Substitute.For<ConsolePrint>();
            _fakeLogPrint = Substitute.For<Log>();
            _fakedataCalculator = Substitute.For<IDataCalculator>();
            _uut = new SeperationChecker(_fakedataCalculator);
        }



        [Test]
        public void ConsolePrint_Is_Correct()
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

            _fakedataCalculator.CalcedDataReady += Raise.EventWith(this, new SeperationEventArgs(_fakeplaneList));


            //Den printer to flyet 2 gange, but why?
            _fakeConsolePrint.Received().PrintPlane(_fakeplaneList);
        }

        [Test]
        public void ConsoleWarringPrint_Is_Correct()
        {
            List<Plane> _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10000;
            p._ycoor = 10000;
            p._altitude = 100000;
            //p._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            Plane p1 = new Plane();
            p1._tag = "ATR321";
            p1._xcoor = 10;
            p1._ycoor = 10;
            p1._altitude = 10;
            //p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p1._compassCourse = 90;
            p1._velocity = 80;

            _fakeplaneList.Add(p);
            _fakeplaneList.Add(p1);
            _uut.DistanceChecker(_fakeplaneList);

            _fakeConsolePrint.Received().PrintWarning(p,p1, DateTime.Now);
        }

        [Test]
        public void Log_Is_Correct()
        {
            List<Plane> _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10000;
            p._ycoor = 10000;
            p._altitude = 100000;
            //p._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            Plane p1 = new Plane();
            p1._tag = "ATR321";
            p1._xcoor = 10;
            p1._ycoor = 10;
            p1._altitude = 10;
            //p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p1._compassCourse = 90;
            p1._velocity = 80;

            _fakeplaneList.Add(p);
            _fakeplaneList.Add(p1);
            _uut.DistanceChecker(_fakeplaneList);

            _fakeLogPrint.Received().PrintWarning(p, p1, DateTime.Now);

        }



    }
}
