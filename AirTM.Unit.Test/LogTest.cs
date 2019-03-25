using System;
using System.Collections.Generic;
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
        private ConsolePrint _uut;
        private SeperationChecker _fakeSeperationChecker;
        private List<Plane> _fakeplaneList;

        [SetUp]
        public void SetUp()
        {
            _uut = new ConsolePrint();
            _fakeSeperationChecker = Substitute.For<SeperationChecker>();

        }


        [Test]
        public void Log_Is_Correct_And_Prints()
        {

        }

    }
}
