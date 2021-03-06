﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public interface ITrackInfo
    {
        event EventHandler<DataCalcEventArgs> AirspaceDataReady;
        
        List<Plane> PlanesInAirSpaceList { get; set; }
     
        List<Plane> Airspace(List<Plane> planeliste);
     
    }
}
