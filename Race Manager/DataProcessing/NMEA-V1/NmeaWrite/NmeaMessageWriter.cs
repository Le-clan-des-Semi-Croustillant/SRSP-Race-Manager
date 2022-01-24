namespace Race_Manager.DataProcessing.NMEA.NmeaWrite
{
    public class NmeaMessageWriter
    {
        public static string Checksum(string trame)
        {
            int checksumTest = 0;
            for (int i = 1; i < trame.Length; i++)
            {
                var c = trame[i];
                checksumTest ^= Convert.ToByte(c);
            }
            return checksumTest.ToString("X2");
        }

    }


}
