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
    public class SeperationCheckerTest
    {
        private IPrint _fakeConsolePrint;
        private SeperationChecker _uut;
        private IPrint _fakeLogPrint;
        private List<Plane> _fakeplaneList;
        private IDataCalculator _fakedataCalculator;


        [SetUp] 
        public void SetUp()
        {
            _fakeConsolePrint = Substitute.For<IPrint>();
            _fakeLogPrint = Substitute.For<IPrint>();
            _fakedataCalculator = Substitute.For<IDataCalculator>();
            _uut = new SeperationChecker(_fakedataCalculator, _fakeLogPrint, _fakeConsolePrint);
        }



        [Test]
        public void ConsolePrint_Is_Recives_list_Correct()
        {
             _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            _fakedataCalculator.CalcedDataReady += Raise.EventWith(this, new SeperationEventArgs(_fakeplaneList));
            _fakeConsolePrint.Received(1).PrintPlane(_fakeplaneList);
           
        }

        [Test]
        public void ConsolePrint_Prints_Correct_tag()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._tag.Contains("TRE123")));

        }



        [Test]
        public void ConsolePrint_Prints_Correct_xcoor()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);
            
            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._xcoor.Equals(10)));
            
        }

        [Test]
        public void ConsolePrint_Prints_Correct_ycoor()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._ycoor.Equals(20)));

        }



        [Test]
        public void ConsolePrint_Prints_Correct_alititude()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);
            
            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._altitude.Equals(30)));

        }

        [Test]
        public void ConsolePrint_Prints_Correct_time()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            var _time = p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._time.Equals(_time)));

        }


        [Test]
        public void ConsolePrint_Prints_Correct_velocity()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            var _time = p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);
            
            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._velocity.Equals(80)));

        }


        [Test]
        public void ConsolePrint_Prints_Correct_course()
        {
            var _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10;
            p._ycoor = 20;
            p._altitude = 30;
            var _time = p._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);
            
            _fakeConsolePrint.PrintPlane(_fakeplaneList);
            _fakeConsolePrint.Received().PrintPlane(Arg.Is<List<Plane>>(_plane => _plane[0]._compassCourse.Equals(90)));

        }

        [Test]
        public void ConsoleWarringPrint_Is__Recived_1()
        {
            List<Plane> _fakeplaneList = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 100;
            p._ycoor = 100;
            p._altitude = 100;
            p._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;
            

            Plane p1 = new Plane();
            p1._tag = "ATR321";
            p1._xcoor = 10;
            p1._ycoor = 10;
            p1._altitude = 10;
            p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p1._compassCourse = 90;
            p1._velocity = 80;

            _fakeplaneList.Add(p);
            _fakeplaneList.Add(p1);
            _uut.DistanceChecker(_fakeplaneList);
            _fakeConsolePrint.Received(1).PrintWarning(p,p1);

           
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
            p._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;
            _fakeplaneList.Add(p);

            Plane p1 = new Plane();
            p1._tag = "ATR321";
            p1._xcoor = 10;
            p1._ycoor = 10;
            p1._altitude = 10;
            p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p1._compassCourse = 90;
            p1._velocity = 80;

            _fakeplaneList.Add(p);
            _fakeplaneList.Add(p1);
            _uut.DistanceChecker(_fakeplaneList);

            _fakeLogPrint.DidNotReceive().PrintWarning(p, p1);

        }


        [Test]
        public void correctListIsCreated()
        {
            List<Plane> planelist = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10000;
            p._ycoor = 10000;
            p._altitude = 100000;
            p._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;
            
            Plane p1 = new Plane();
            p1._tag = "ATR321";
            p1._xcoor = 10;
            p1._ycoor = 10;
            p1._altitude = 10;
            p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            p1._compassCourse = 90;
            p1._velocity = 80;
            planelist.Add(p);
            planelist.Add(p1);

            _fakedataCalculator.CalcedDataReady += Raise.EventWith(this, new SeperationEventArgs(planelist));

            Assert.That(_uut._planelist.Count, Is.EqualTo(2));




        }
    }
}
