using System;
using System.Collections.Generic;
using ATM_System;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;



namespace AirTM.Unit.Test
{
    [TestFixture]
    public class DataCalcTest
    {
        private ITrackInfo _fakeTrackInfo;
        private DataCalculator _uut;


        private List<Plane> planelist;
        private List<Plane> gammelliste;
        private Plane _plane1;
        private Plane _plane2;
        private Plane _plane3;
        private Plane _plane4;

        [SetUp]
        public void SetUp()
        {
            _fakeTrackInfo = Substitute.For<ITrackInfo>();
            _uut = new DataCalculator(_fakeTrackInfo);

            var dateTime1 = new DateTime(2019, 06, 05, 10, 54, 34);
            var dateTime2 = new DateTime(2019, 06, 05, 10, 54, 50);
            var dateTime3 = new DateTime(2019, 06, 05, 10, 50, 00); 
            var dateTime4 = new DateTime(2019, 06, 05, 10, 50, 02);
            _plane1 = new Plane
            {
                _tag = "ART123",
                _xcoor = 12345,
                _ycoor = 67891,
                _altitude = 23456,
                _time = dateTime1,


            };

            _plane2 = new Plane
            {
                _tag = "ART123",
                _xcoor = 98765,
                _ycoor = 43210,
                _altitude = 12345,
                _time = dateTime2,
            };

            _plane3 = new Plane
            {
                _tag = "TRE123",
                _xcoor = 6,
                _ycoor = 4,
                _altitude = 12345,
                _time = dateTime3,


            };

            _plane4 = new Plane
            {
                _tag = "TRE123",
                _xcoor = 9,
                _ycoor = 8,
                _altitude = 12345,
                _time = dateTime4,
            };
        }

        [Test]
        public void Test_Input_correct()
        {
            List<Plane> planelist = null;
            List<Plane> pl = new List<Plane>();
            Plane p = new Plane();
            p._tag = "ATR123";
            p._xcoor = 900;
            p._ycoor = 800;
            p._altitude = 100;
            DateTime date = new DateTime(2015, 10, 06, 21, 34, 56, 798);
            p._time = (DateTime.ParseExact("20151006213456798", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));

            pl.Add(p);

            _uut.CalcedDataReady += (o, e) => { planelist = e.CalcedInfo; }; //Simulates formatted data ready event
            _fakeTrackInfo.AirspaceDataReady += Raise.EventWith(this, new DataCalcEventArgs(pl));

            Assert.That(planelist[0]._tag, Is.EqualTo("ATR123"));
            Assert.That(planelist[0]._xcoor, Is.EqualTo(900));
            Assert.That(planelist[0]._ycoor, Is.EqualTo(800));
            Assert.That(planelist[0]._altitude, Is.EqualTo(100));
            Assert.That(planelist[0]._time, Is.EqualTo(date));
            Assert.That(planelist[0]._compassCourse, Is.EqualTo(0));
            Assert.That(planelist[0]._velocity, Is.EqualTo(0));
        }

        //TEST AF VELOCITY
        [Test]
        public void velocity_med_3_4_Correct()
        {
            planelist = new List<Plane>();
            planelist.Add(_plane3);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane4);

            _uut.gammelliste = gammelliste;
            _uut.nyliste = planelist;
            _uut.CalculateVelocity();

            Assert.That(_uut.nyliste[0]._velocity, Is.EqualTo(2.5));

        }


        [TestCase("ATR123", 900, 800, 1000, "20151006213400000", "ATR123", 600, 400, 1000, "20151006213410000", 50)]
        [TestCase("ATR123", 9, 8, 1, "20190605105000000", "ATR123", 6, 4, 1, "20190605105002000", 2.5)]

        public void TestcaseVelocity(string tag, int x1, int y1, int a1, string tid1, string tag2, int x2, int y2, int a2, string tid2, double result)
        {
            gammelliste = new List<Plane>();
            Plane p1 = new Plane();
            p1._tag = tag;
            p1._xcoor = x1;
            p1._ycoor = y1;
            p1._altitude = a1;
            p1._time =
                (DateTime.ParseExact(tid1, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            gammelliste.Add(p1);

            planelist = new List<Plane>();
            Plane p2 = new Plane();
            p2._tag = tag2;
            p2._xcoor = x2;
            p2._ycoor = y2;
            p2._altitude = a2;
            p2._time =
                (DateTime.ParseExact(tid2, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            planelist.Add(p2);

           
            _uut.gammelliste = gammelliste;
            _uut.nyliste = planelist;
            _uut.CalculateVelocity();
            Assert.That(_uut.nyliste[0]._velocity, Is.EqualTo(result).Within(00.01));
        }


         //TEST AF COURSE; North, south, east, west
        [TestCase("ATR123", 1, 1, 1, "ATR123", 1, 2, 1, 0)]
        [TestCase("TRE123", 0, 1, 0, "TRE123", 0, 0, 1, 180)]
        [TestCase("NHM546", 1, -1,-1, "NHM546", 2, -1,1, 270)]
        [TestCase("LKS165", 2, 2, 1, "LKS165", 1, 2, 1, 90)]
        public void calculatecourseTestcase(string tag1, int x1, int y1, int a1, string tag2, int x2, int y2, int a2,  double result)
        {
            gammelliste = new List<Plane>();
            Plane p1 = new Plane();
            p1._tag = tag1;
            p1._xcoor = x1;
            p1._ycoor = y1;
            p1._altitude = a1;
            p1._time  = DateTime.Now;
            gammelliste.Add(p1);
            _uut.gammelliste = gammelliste;


            planelist = new List<Plane>();
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
            gammelliste = new List<Plane>();
            Plane p1 = new Plane();
            p1._tag = tag1;
            p1._xcoor = x1;
            p1._ycoor = y1;
            p1._altitude = a1;
            p1._time = DateTime.Now;
            gammelliste.Add(p1);
            _uut.gammelliste = gammelliste;


            planelist = new List<Plane>();
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


        [Test]
        public void compass_isCorrect()
        {
            planelist = new List<Plane>();
            planelist.Add(_plane2);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane1);
            
            _uut.CalculateCourse(gammelliste, planelist);
            Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(106).Within(00.01));
        }

        [Test]
        public void correctListIsCreated()
        {
            planelist = new List<Plane>();
            planelist.Add(_plane1);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane2);
            DataCalcEventArgs testArgs = new DataCalcEventArgs(gammelliste);

            _uut.UseList(this, testArgs);
            testArgs = new DataCalcEventArgs(planelist);
            _uut.UseList(this, testArgs);

            Assert.That(_uut.gammelliste[0]._velocity, Is.EqualTo(5659.97));

        }


    }

}
