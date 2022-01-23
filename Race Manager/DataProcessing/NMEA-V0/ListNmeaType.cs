namespace Race_Manager.DataProcessing.NMEAV0
{
    public class ListNmeaType
    {
        public static readonly Dictionary<string, string> IdTalker = new Dictionary<string, string>()
        {
            {"GP", "Global Positioning System"},
            {"LC", "Loran-C receiver"},
            {"OM", "Omega Navigation receiver"},
            {"II", "Integrated Instrumentation"},
        };

        public static readonly Dictionary<string, string> IdFrame = new Dictionary<string, string>()
        {
            {"GGA", "GPS Fix and Date"},
            {"GLL", "Geographic Location Longitude - Latitude"},
            {"GSA", "DOP and satellites actifs"},
            {"GSV", "Visible satellites"},
            {"VTG", "Direction and speed of travel"},
            {"RMC", "Specific minimum usable data"},
        };
    }
}
