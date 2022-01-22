using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race_Manager.DataProcessing.NMEA;

namespace consoleTests
{
    internal class Launcher_NMEA_001
    {
        public static int Main(String[] args)
        {
            string NmeaType = "$GPGGA,064036.289,4836.5375,N,00740.9373,E,1,04,3.2,200.2,M,,,,0000*0E";
            //string[] test = NmeaParse.Parsing(NmeaType);
            //Console.WriteLine(test[0]);
            NmeaParse.Parse(NmeaType);
            //Console.WriteLine(string.Join("\n", test));
            //string IdTalker = NmeaParse.ParsingIdTalker(test[0]);
            //string IdFrame = NmeaParse.ParsingIdFrame(test[0]);
            //Console.WriteLine(IdFrame.Length);
            return 0;
        }
    }
}
