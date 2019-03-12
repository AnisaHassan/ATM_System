using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_System
{
    public class TrackInfo
    {
        public List<Plane> TrackedDataInfo { get; set; }
        private IDataCalculator _dataCalculator;
        private List<Plane> gammelliste;
        private List<Plane> dataliste;

        public TrackInfo()
        {
         
        }

        public TrackInfo(IDataCalculator dataCalculator)
        {
            _dataCalculator = dataCalculator;
            gammelliste = new List<Plane>();
        }

      public void AirSpace(List<Plane> planelist)

        {
            TrackedDataInfo = new List<Plane>();

            foreach (var _plane in planelist)
            {
                if (_plane._xcoor <= 90000 && _plane._xcoor >= 10000 && _plane._ycoor >= 10000 &&
                    _plane._ycoor <= 90000)

                    TrackedDataInfo.Add(_plane);
                //Mangler du ikke {} omkring planelist.Add(_plane); ???

            }

            dataliste = new List<Plane>();

            gammelliste = dataliste;

        }

    }

}
