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
      private Plane _track1;
      private Plane _track2;
      private List<Plane> gammelListe;

        [SetUp]
      public void SetUp()
      {

          uut = new DataCalculator();
          var dateTime1 = new DateTime(2018, 04, 05, 20, 20, 18);
          var dateTime2 = new DateTime(2018, 04, 05, 20, 20, 20);
            _track1 = new Plane
          {
              _tag = "ART423",
              _xcoor = 12345,
              _ycoor = 98765,
              _time = dateTime1,
            

          };

          _track2 = new Plane
          {
              _tag = "ART423",
              _xcoor = 92345,
              _ycoor = 88765,
              _time = dateTime2,


          };
          planelist = new List<Plane>
          {
              _track1,
              _track2
          };

        }
        [Test]
      public void velocity_isCorrect()
      {

          uut.CalculateVelocity(planelist, gammelListe);
          Assert.That(Math.Round(uut.nyliste[1]._velocity, 2), Is.EqualTo(40311.29));
      }



    }
}
