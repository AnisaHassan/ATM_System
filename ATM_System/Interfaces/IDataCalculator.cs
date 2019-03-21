using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Events;

namespace ATM_System
{
   public interface IDataCalculator
   {
       event EventHandler<SeperationEventArgs> CalcedDataReady;

        List<Plane> nyliste { get; set; }
       List<Plane> gammelliste { get; set; }

        void CalculateVelocity();
       void CalculateCourse(List<Plane> gammelliste, List<Plane> nyliste);

   }



}
