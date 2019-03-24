using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiver;
using ATM_System;
using NSubstitute;


namespace AirTM.Unit.Test
{
    [TestFixture]
    public class SeperationCheckerTest
    {
        private IDataCalculator _fakedataCalculator;
        private IPrint _fakeConsolePrint;
        private IPrint _fakeLogPrint;
        private SeperationChecker _uut;
        private List<Plane> _fakeplaneList;


        [SetUp] 
        public void SetUp()
        {
            _fakeConsolePrint = Substitute.For<ConsolePrint>();
            _fakeLogPrint = Substitute.For<Log>();
            _fakedataCalculator = Substitute.For<IDataCalculator>();
            _uut = new SeperationChecker(_fakedataCalculator, _fakeConsolePrint,_fakeLogPrint);
        }



        [Test]
        public void PrintWithoutSeperation()
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

            _fakeplaneList = _uut.CheckDistance(_)
            _fakedataCalculator.CalcedDataReady += Raise.EventWith(this, new DataCalcEventArgs(_fakeplaneList));

            _fakeConsolePrint.Received().PrintPlane(_fakeplaneList);


            
        }
    }
}
