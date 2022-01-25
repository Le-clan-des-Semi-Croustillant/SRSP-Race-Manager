namespace RaceManager.DataProcessing.NMEAV0.NmeaType
{
    public class GGA
    {
        public GGA(string NmeaIdTalker, string[] NmeaMessage)
        {
            if (NmeaMessage == null || NmeaMessage.Length < 14)
            {
                Console.WriteLine("Invalid GGA message");
                return;
            }
            FixTime = NmeaMessage[0];
        }

        public string FixTime { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
