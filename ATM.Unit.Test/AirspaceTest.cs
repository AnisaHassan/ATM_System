using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class AirSpaceTest
    {
        private ITrackInfo uut;
        private Plane plane_;
        private List<Plane> _planeList;


        [SetUp]
        public void SetUp()
        {
            uut = new ITrackInfo();
            _planeList = new List<Plane>();
        }

        public void TrackIsInAirspace_TrackIsOk()
        {
            plane_ = new Plane { _xcoor = 89999, _ycoor = 89999 };

            _planeList.Add(plane_);

           

            Assert.That(_planeList.Count, Is.EqualTo(1));
        }



    }
}
