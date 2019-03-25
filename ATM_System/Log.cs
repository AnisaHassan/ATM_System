using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class Log : IPrint
    {
        public void PrintWarning(Plane plane1, Plane plane2)
        {
            //string filen = ("WARNING! Separation to small between " + plane1._tag + " and " + plane2._tag + " at " + plane2._time + System.Environment.NewLine);

            //System.IO.File.AppendAllText("eperationslog.txt", filen);


            //using (StreamWriter fileWriter = new FileInfo("Seperationslog.txt").AppendText())
            //{
            //    fileWriter.WriteLine("WARNING! Separation to small between " + plane1._tag + " and " + plane2._tag + " at " + plane2._time);
            //}



            FileStream output = new FileStream("Seperationslog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter fileWriter = new StreamWriter(output);
            fileWriter.WriteLine("WARNING! Separation to small between " + plane1._tag + " and " + plane2._tag +  " at " + plane2._time);
            fileWriter.Close();

        }




        public void PrintPlane(List<Plane> planeliste) {  }
    }
}
