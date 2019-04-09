using System;
using System.Collections.Generic;
using ATM_System;
using ATM_System.Events;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;



namespace AirTM.Unit.Test
{
    [TestFixture]
    public class DataCalcTest
    {
        private ITrackInfo _fakeTrackInfo;
        private IDataCalculator _uut;
        private SeperationEventArgs output;
       
        [SetUp]
        public void SetUp()
        {
            _fakeTrackInfo = Substitute.For<ITrackInfo>();
            _uut = new DataCalculator(_fakeTrackInfo);
            _uut.CalcedDataReady += (o, a) => { output = a; };
        }

        [Test]
        public void Test_Input_correct()
        {
            List<Plane> planelist = new List<Plane>();
            Plane p = new Plane();
            p._tag = "ATR123";
            p._xcoor = 600;
            p._ycoor = 400;
            p._altitude = 100;
            p._time = (DateTime.ParseExact("20151006213456798", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            planelist.Add(p);


            List<Plane> planelist1 = new List<Plane>();
            Plane p1 = new Plane();
            p1._tag = "ATR123";
            p1._xcoor = 900;
            p1._ycoor = 800;
            p1._altitude = 100;
            p1._time = (DateTime.ParseExact("20151006213458798", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            DateTime date = new DateTime(2015, 10, 06, 21, 34, 58, 798);

            planelist1.Add(p1);


            // Act: Trigger the fake object to execute event invocation
            _fakeTrackInfo.AirspaceDataReady += Raise.EventWith(this, new DataCalcEventArgs(planelist));
            _fakeTrackInfo.AirspaceDataReady += Raise.EventWith(this, new DataCalcEventArgs(planelist1));

            Assert.That(output.CalcedInfo[0]._tag, Is.EqualTo("ATR123"));
            Assert.That(output.CalcedInfo[0]._xcoor, Is.EqualTo(900));
            Assert.That(output.CalcedInfo[0]._ycoor, Is.EqualTo(800));
            Assert.That(output.CalcedInfo[0]._altitude, Is.EqualTo(100));
            Assert.That(output.CalcedInfo[0]._time, Is.EqualTo(date));
            Assert.That(output.CalcedInfo[0]._compassCourse, Is.EqualTo(36.86989764584402d));
            Assert.That(output.CalcedInfo[0]._velocity, Is.EqualTo(250));
        }

        //TEST AF COURSE; North, south, east, west
        [TestCase("ATR123", 1, 1, 1, "ATR123", 1, 2, 1, 0)]
        [TestCase("TRE123", 0, 1, 0, "TRE123", 0, 0, 1, 180)]
        [TestCase("NHM546", 1, -1, -1, "NHM546", 2, -1, 1, 270)]
        [TestCase("LKS165", 2, 2, 1, "LKS165", 1, 2, 1, 90)]
        public void calculatecourseTestcase(string tag1, int x1, int y1, int a1, string tag2, int x2, int y2, int a2, double result)
        {
            List<Plane> gammelliste = new List<Plane>();
            Plane p1 = new Plane();
            p1._tag = tag1;
            p1._xcoor = x1;
            p1._ycoor = y1;
            p1._altitude = a1;
            p1._time = DateTime.Now;
            gammelliste.Add(p1);
            _uut.gammelliste = gammelliste;


            List<Plane> planelist = new List<Plane>();
            Plane p2 = new Plane();
            p2._tag = tag2;
            p2._xcoor = x2;
            p2._ycoor = y2;
            p2._altitude = a2;
            p2._time = DateTime.Now;
            planelist.Add(p2);
            _uut.nyliste = planelist;

            _uut.CalculateCourse(gammelliste, planelist);
            Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(result).Within(00.01));

        }

        //TEST AF COURSE
        [TestCase("ATR123", 1, 1, 1, "ATR123", 2, 2, 1, 45)]
        [TestCase("TRE123", 2, 1, 1, "TRE123", 1, 2, 1, 315)]
        [TestCase("NHM546", 2, 2, 1, "NHM546", 1, 1, 1, 225)]
        [TestCase("LKS165", 1, 2, 1, "LKS165", 2, 1, 1, 135)]
        public void CourseTestcase(string tag1, int x1, int y1, int a1, string tag2, int x2, int y2, int a2, double result)
        {
            List<Plane> gammelliste = new List<Plane>();
            Plane p1 = new Plane();
            p1._tag = tag1;
            p1._xcoor = x1;
            p1._ycoor = y1;
            p1._altitude = a1;
            p1._time = DateTime.Now;
            gammelliste.Add(p1);
            _uut.gammelliste = gammelliste;


            List<Plane> planelist = new List<Plane>();
            Plane p2 = new Plane();
            p2._tag = tag2;
            p2._xcoor = x2;
            p2._ycoor = y2;
            p2._altitude = a2;
            p2._time = DateTime.Now;
            planelist.Add(p2);
            _uut.nyliste = planelist;

            _uut.CalculateCourse(gammelliste, planelist);
            Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(result).Within(00.01));

        }

    }

}
