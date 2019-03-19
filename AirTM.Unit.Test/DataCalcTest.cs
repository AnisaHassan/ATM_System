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
          var dateTime1 = new DateTime(2018, 04, 05, 20, 20, 18);
          var dateTime2 = new DateTime(2018, 04, 05, 20, 20, 20);
            _plane1 = new Plane
          {
              _tag = "ART123",
              _xcoor = 12345,
              _ycoor = 67891,
              _altitude = 12345,
              _time = dateTime1,
            

          };

          _plane2 = new Plane
          {
              _tag = "ART123",
              _xcoor = 98765,
              _ycoor = 45678,
              _altitude = 12345,
              _time = dateTime2,



          };
          planelist = new List<Plane>
          {
              _plane1,
              _plane1
          };

        }
        [Test]
      public void velocity_isCorrect()
      {

          uut.CalculateVelocity(gammelliste, planelist);
          Assert.That(Math.Round(planelist[0]._velocity, 2), Is.EqualTo(44614.55));
      }

      [Test]
        public void coursecompass_isCorrect()
      {
          uut.CalculateCourse(gammelliste, planelist);
          Assert.That(Math.Round(planelist[0]._compassCourse), Is.EqualTo(44614.55));
        }


}
}
