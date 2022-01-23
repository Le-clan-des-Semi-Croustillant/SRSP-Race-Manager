namespace Race_Manager.DataProcessing.NMEA
{
    //[NmeaMessageType("GLL")]
    public class GLL
    {
        public GLL(string NmeaIdTalker, string[] NmeaMessage)
        {
            FixTime = NmeaMessage[0];
            Console.WriteLine("test");
        }

        public string FixTime { get; }

    }
}
