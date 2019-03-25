using System;
using System.Collections.Generic;
using System.IO;
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
   public class LogTest
    {
        private IPrint _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new Log();
            File.WriteAllText("Seperationslog.txt", string.Empty);

        }


        [Test]
        public void Log_Is_Correct_With_TwoPlanes()
        {
            Plane p1 = new Plane();
            p1._tag = "TRE123";
            p1._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);

            Plane p2 = new Plane();
            p2._tag = "ARE321";
            p2._time = new DateTime(2019, 04, 30, 15, 57, 30, 123);

            _uut.PrintWarning(p1, p2);

            var file = File.ReadAllLines("seperationslog.txt");
            var fil = file[0];
            Assert.That(fil,
                Is.EqualTo("WARNING! Separation to small between TRE123 and ARE321 at 30-04-2019 15:57:30"));
        }

    }
}
