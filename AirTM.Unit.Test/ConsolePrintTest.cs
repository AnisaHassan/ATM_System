using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATM_System;

namespace AirTM.Unit.Test
{
    [TestFixture]
    public class ConsolePrintTest
    {
        private IPrint _uut;
        private List<Plane> planelist;

        [SetUp]
        public void SetUp()
        {
            _uut = new ConsolePrint();
            
            

        }

        [Test]
        public void Print_warning_with_Full_Planes()
        {

            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10000;
            p._ycoor = 10000;
            p._altitude = 100000;
            p._time = (DateTime.ParseExact("20190430121230000", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;


            Plane p1 = new Plane();
            p1._tag = "ATR321";
            p1._xcoor = 10;
            p1._ycoor = 10;
            p1._altitude = 10;
            p1._time = (DateTime.ParseExact("20190430121230210", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture));
            p1._compassCourse = 90;
            p1._velocity = 80;

            _uut.PrintWarning(p ,p1);

            string text = _uut._text;

            Assert.That(text,
               Is.EqualTo("WARNING! Separation too small between" + " TRE123 and ATR321 at 30/04/19 12.12.30"));


        }

        [Test]
        public void Print_with_Full_Planes()
        {
            planelist = new List<Plane>();
            Plane p = new Plane();
            p._tag = "TRE123";
            p._xcoor = 10000;
            p._ycoor = 10000;
            p._altitude = 100000;
            p._time = (DateTime.ParseExact("20190430121230000", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture));
            p._compassCourse = 90;
            p._velocity = 80;

            planelist.Add(p);

            _uut.PrintPlane(planelist);

            string text = _uut._text;

            Assert.That(text,
                Is.EqualTo("Tag: " + "TRE123" + "\nX-coordinate: " + "10000" +
                           " meters\nY-coordinate: " +
                           "10000" + " meters\nAltitude: " + "100000" +
                           " meters\nTime stamp: " + "2019" + "/" + "4" +
                           "/" + "30" +
                           ", at " + "12" + ":" + "12" + ":" +
                           "30" + " and " + "0" + " milliseconds\nVelocity: " + "80" + " m/s\nCourse: " +
                           "90" + " degrees\n"));

            

        }

    }
}
