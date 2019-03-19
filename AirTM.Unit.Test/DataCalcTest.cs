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
        private IDataCalculator uut;
        private List<Plane> planelist;

        private List<Plane> gammelliste;
        private Plane _plane1;
        private Plane _plane2;
      [SetUp]
      public void SetUp()
      {
          uut = new DataCalculator();
          var dateTime1 = new DateTime(2019, 06, 05, 10, 54, 34);
          var dateTime2 = new DateTime(2019, 06, 05, 10, 54, 50);
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

      }
        [Test]
      public void velocity_isCorrect()
      {
          planelist = new List<Plane>();
          planelist.Add(_plane1);
          gammelliste = new List<Plane>();
          gammelliste.Add(_plane2);
          

            uut.CalculateVelocity(gammelliste, planelist);
            Assert.That(gammelliste[0]._velocity, Is.EqualTo(5659.97));

        }
        [Test]
        public void compass_isCorrect()
        {
            planelist = new List<Plane>();
            planelist.Add(_plane1);
            gammelliste = new List<Plane>();
            gammelliste.Add(_plane2);

            uut.CalculateCourse(gammelliste, planelist);
            Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(344));
        }

    


}
}
