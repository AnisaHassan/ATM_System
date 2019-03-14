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
    class TrackInfoTest
    {
        [TestFixture]
        public class TrackRecieverTest
        {
            private TrackInfo _uut;
            private List<string> stringList;
            private List<Plane> planeList;

            [SetUp]
            public void SetUp()
            {
                _uut = new TrackInfo();

                string plane = "39045;12932";

                stringList = new List<string>();

                stringList.Add(plane);
                planeList = _uut.TrackedDataInfo(stringList);

            }
        }
    }
}

