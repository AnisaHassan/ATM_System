﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class ITrackInfo
    {
        public event EventHandler<DataCalcEventArgs> AirspaceDataReady;
    }
}
