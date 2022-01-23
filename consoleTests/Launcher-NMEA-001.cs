using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race_Manager.DataProcessing.NMEA;
using Race_Manager.DataProcessing.NMEA.NmeaRead;
using Race_Manager.DataProcessing.NMEA.NmeaType;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace consoleTests
{
    internal class Launcher_NMEA_001
    {
        public static int Main(String[] args)
        {
            //string input1 = "$GPRMC,130423,A,4628.5842,N,00146.7596,W,5.4000,45.0000,081120,0.0,W,A*28";
            //var msg213 = NmeaMessage.Parse(input1);
            //Console.WriteLine(msg213);
            //string input2= "$GPMWV,-35.0000,R,20.0000,N,A*00";
            //msg213 = NmeaMessage.Parse(input2);
            //Console.WriteLine(msg213);
            //string input3 = "$GPVHW,35.0000,T,,M,5.0000,N,,K*72";
            //msg213 = NmeaMessage.Parse(input3);
            //Console.WriteLine(msg213);

            string info = "$VBRMC,170423,A,4643.8214,N,00124.5556,W,5.4000,45.0000,081120,0.0,W,A*2F";
            var msginfo = NmeaMessage.Parse(info);
            Console.WriteLine(msginfo);
            info = "$VBMWV,-35.0000,R,20.0000,N,A*00";
            msginfo = NmeaMessage.Parse(info);
            Console.WriteLine(msginfo);
            info = "$VBVHW,35.0000,T,,M,5.0000,N,,K*72";
            msginfo = NmeaMessage.Parse(info);
            Console.WriteLine(msginfo);
            info = "$IIXDR,A,3.0000,D,PTCH,A,10.0000,D,ROLL*6E";
            msginfo = NmeaMessage.Parse(info);
            Console.WriteLine(msginfo);
            info = "$IIRSA,-2.0000,A,,V*66";
            msginfo = NmeaMessage.Parse(info);
            Console.WriteLine(msginfo);
            //info = "!AIVDM,1,1,,A,15o588? P0nOqS8HJgDAQhgvt0000,0*20";
            //msginfo = NmeaMessage.Parse(info);
            //Console.WriteLine(msginfo);

            //string NmeaType = "$GPGGA,064036.289,4836.5375,N,00740.9373,E,1,04,3.2,200.2,M,,,,0000*0E";
            //string NmeaType = "$GPGGA,235236,3925.9479,N,11945.9211,W,1,10,0.8,1378.0,M,-22.1,M,,*46";
            string NmeaType = "$GPGGA,123519,4807.038,N,01131.324,E,1,08,0.9,545.4,M,46.9,M,,*42";
            string input = "$GPRMA,A,4917.24,S,12309.57,W,1000.0,2000.0,123.4,321.0,10,E,A*38";
            var msg = NmeaMessage.Parse(input);
            Console.WriteLine(msg);
            Console.WriteLine(msg.MessageType);
            var msg2 = NmeaMessage.Parse(NmeaType);
            Console.WriteLine(msg2);
            Console.WriteLine(msg2.MessageType);
            Console.WriteLine(msg2.TalkerId);
            Console.WriteLine(msg2.Timestamp);
            Console.WriteLine(msg2.IsProprietary);
            Console.WriteLine(msg2.Checksum);
            //Console.WriteLine(msg2);
            Console.WriteLine("");
            Gga gga = (Gga)msg2;
            Console.WriteLine("FixTime : " + gga.FixTime);
            Console.WriteLine("Latitude : " + gga.Latitude);
            Console.WriteLine("LatitudeVal : " + gga.LatitudeVal);
            Console.WriteLine("LatitudeCard : " + gga.LatitudeCard);
            Console.WriteLine("Longitude : " + gga.Longitude);
            Console.WriteLine("LongitudeVal : " + gga.LongitudeVal);
            Console.WriteLine("LongitudeCard : " + gga.LongitudeCard);
            Console.WriteLine("Quality int : " + ((int)gga.Quality));
            Console.WriteLine("Quality : " + (gga.Quality));
            Console.WriteLine("NumberOfSatellites : " + gga.NumberOfSatellites);
            Console.WriteLine("Hdop : " + gga.Hdop);
            Console.WriteLine("Altitude : " + gga.Altitude);
            Console.WriteLine("AltitudeUnits : " + gga.AltitudeUnits);
            Console.WriteLine("GeoidalSeparation : " + gga.GeoidalSeparation);
            Console.WriteLine("GeoidalSeparationUnits : " + gga.GeoidalSeparationUnits);
            Console.WriteLine("TimeSinceLastDgpsUpdate : " + gga.TimeSinceLastDgpsUpdate);
            Console.WriteLine("DgpsStationId : " + gga.DgpsStationId);
            Console.WriteLine("Checksum : " + gga.Checksum);
            Console.WriteLine("Timestamp : " + gga.Timestamp);
            Console.WriteLine("IsProprietary : " + gga.IsProprietary);


            //string[] test = NmeaParse.Parsing(NmeaType);
            //Console.WriteLine(test[0]);
            //NmeaParse.Parse(NmeaType);
            //Console.WriteLine(string.Join("\n", test));
            //string IdTalker = NmeaParse.ParsingIdTalker(test[0]);
            //string IdFrame = NmeaParse.ParsingIdFrame(test[0]);
            //Console.WriteLine(IdFrame.Length);
            return 0;
        }
    }
}
