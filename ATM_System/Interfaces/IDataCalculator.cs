﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
   public interface IDataCalculator
   {
       List<Plane> nyliste { get; set; }

       void CalculateVelocity( List<Plane> planeNew);
       void CalculateCourse(List<Plane> planeOld, List<Plane> planeNew);

   }



}
