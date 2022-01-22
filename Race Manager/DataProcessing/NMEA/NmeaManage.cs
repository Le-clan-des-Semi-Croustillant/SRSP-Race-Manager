using System.Globalization;
using Race_Manager.DataProcessing.NMEA;

namespace Race_Manager.DataProcessing.NMEA
{
    //public class NmeaManage
    //{
    //    public string NmeaType = "$GPGGA,064036.289,4836.5375,N,00740.9373,E,1,04,3.2,200.2,M,,,,0000*0E";

    //}

    public class NmeaParse
    {
        public static void Parse(string NmeaFrame)
        {
            if (string.IsNullOrEmpty(NmeaFrame))
            {
                Console.WriteLine("Invalid NMEA message : Message empty" + NmeaFrame + ".");
                return;
            }

            if (NmeaFrame[0] != '$')
            {
                Console.WriteLine("Invalid NMEA message: Message missing '$'");
                return;
            }

            var idx = NmeaFrame.IndexOf('*');
            int checksum = -1;

            if (idx >= 0)
            {
                if (NmeaFrame.Length > idx + 1)
                {
                    if (int.TryParse(NmeaFrame.Substring(idx + 1), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int c))
                    {
                        checksum = c;
                    }
                    else
                    {
                        Console.WriteLine("Invalid NMEA message: Invalid checksum");
                        return;
                    }
                }
                NmeaFrame = NmeaFrame.Substring(0, NmeaFrame.IndexOf('*'));
            }

            int checksumTest = 0;

            for (int i = 1; i < NmeaFrame.Length; i++)
            {
                var c = NmeaFrame[i];
                if (c < 0x20 || c > 0x7E)
                {
                    Console.WriteLine("Invalid NMEA message: Invalid contains characters");
                    return;
                }
                checksumTest ^= Convert.ToByte(c);
            }
            if (checksum != checksumTest)
            {
                Console.WriteLine("Invalid NMEA message: Invalid checksum. Got : " + checksum + " Expected : " + checksumTest);
                return;
            }

            string[] NmeaFrameSplit = NmeaFrame.Split(",");
            string NmeaIdTalker = NmeaFrameSplit[0].Substring(1,2);
            string NmeaIdFrame = NmeaFrameSplit[0].Substring(3);
            string[] NmeaMessage = NmeaFrameSplit.Skip(1).ToArray();

            if (!ListNmeaType.IdTalker.ContainsKey(NmeaIdTalker))
            {
                Console.WriteLine("Invalid NMEA message: Invalid IdTalker " + NmeaIdTalker);
                return;
            }
            else if (!ListNmeaType.IdFrame.ContainsKey(NmeaIdFrame))
            {
                Console.WriteLine("Invalid NMEA message: Invalid IdFrame " + NmeaIdFrame);
                return;
            }

            

        }
    }
}
