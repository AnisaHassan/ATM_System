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
        private ITransponderReceiver _fakeTransponderReceiver;
        private DataCalculator uut;
        private List<Plane> planelist;
        public List<Plane> TrackedDataInfo { get; set; }
 

        private List<Plane> gammelliste;
        private Plane _plane1;
        private Plane _plane2;
        private Plane _plane3;
        private Plane _plane4;

        [SetUp]
        public void SetUp()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            uut = new DataCalculator(new TrackInfo());
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

        //TEST AF VELOCITY
        [Test]
        public void velocity_med_3_4_Correct()
        {
            //Lambda
           // uut.CalcedDataReady += (o, e) => { planelist = e.CalcedInfo; }; //Simulates formatted data ready event

            planelist = new List<Plane>();
            planelist.Add(_plane3);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane4);

            uut.gammelliste = gammelliste;
            uut.nyliste = planelist;
            uut.CalculateVelocity();

            Assert.That(uut.nyliste[0]._velocity, Is.EqualTo(2.5));

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

           
            uut.gammelliste = gammelliste;
            uut.nyliste = planelist;
            uut.CalculateVelocity();

            Assert.That(uut.nyliste[0]._velocity, Is.EqualTo(result).Within(00.01));
        }


         //TEST AF COURSE
        [Test]
        [TestCase("ATR123", 1, 2, 0, "ATR123", 1, 2, 0, 0)]
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
            uut.gammelliste = gammelliste;


            planelist = new List<Plane>();
            Plane p2 = new Plane();
            p2._tag = tag2;
            p2._xcoor = x2;
            p2._ycoor = y2;
            p2._altitude = a2;
            p2._time = DateTime.Now;
            planelist.Add(p2);
            uut.nyliste = planelist;

            uut.CalculateCourse(gammelliste, planelist);

            Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(result).Within(00.01));
            
        }


       

        [Test]
        public void compass_isCorrect()
        {


            planelist = new List<Plane>();
            planelist.Add(_plane2);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane1);


            uut.CalculateCourse(gammelliste, planelist);
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

            uut.UseList(this, testArgs);
            testArgs = new DataCalcEventArgs(planelist);
            uut.UseList(this, testArgs);

            Assert.That(uut.gammelliste[0]._velocity, Is.EqualTo(5659.97));

        }


    }

}
