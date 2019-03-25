using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;
using ATM_System;

namespace ATM_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the real transponder data receiver
            ITransponderReceiver receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            ITrackReciever trackReciever = new TrackReciever(receiver);
            ITrackInfo trackInfo = new TrackInfo(trackReciever);
            IDataCalculator datacalc = new DataCalculator(trackInfo);
            IPrint consoleprinter = new ConsolePrint();
            IPrint logprinter = new Log();
            ISeperationChecker seperationChecker = new SeperationChecker(datacalc, logprinter, consoleprinter);
         

            //Til udskrivning:
            //DataCalculator datacalculator = new DataCalculator(trackInfo);
            //datacalculator._print = new ConsolePrint();

            Console.ReadKey();


        }
    }
}
