using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
   public interface IDataCalculator
   {

       List<Plane> nyliste { get; set; }
       List<Plane> gammelliste { get; set; }

        void CalculateVelocity();
       void CalculateCourse(List<Plane> gammelliste, List<Plane> nyliste);

   }



}
