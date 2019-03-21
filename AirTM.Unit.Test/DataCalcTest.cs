using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System;
using NUnit.Framework;
using TransponderReceiver;


namespace AirTM.Unit.Test
{
    [TestFixture]
    public class DataCalcTest
    {
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

            uut = new DataCalculator(new TrackInfo());
            var dateTime1 = new DateTime(2019, 06, 05, 10, 54, 34);
            var dateTime2 = new DateTime(2019, 06, 05, 10, 54, 50);
            var dateTime3 = new DateTime(2019, 06, 05, 10, 50, 00);
            var dateTime4 = new DateTime(2019, 06, 05, 10, 50, 10);
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
        public void velocity_isCorrect()
        {
            planelist = new List<Plane>();
            planelist.Add(_plane1);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane2);

            uut.gammelliste = gammelliste;
            uut.nyliste = planelist;
            uut.CalculateVelocity();

            Assert.That(uut.nyliste[0]._velocity, Is.EqualTo(5659.97));

        }
        [Test]
        public void velocity_med_3_4_Correct()
        {
            planelist = new List<Plane>();
            planelist.Add(_plane3);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane4);

            uut.gammelliste = gammelliste;
            uut.nyliste = planelist;
            uut.CalculateVelocity();

            Assert.That(uut.nyliste[0]._velocity, Is.EqualTo(5));

        }
        [Test]
        public void compass_isCorrect()
        {


            planelist = new List<Plane>();
            planelist.Add(_plane1);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane2);

            uut.CalculateCourse(gammelliste, planelist);
            Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(74));
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
