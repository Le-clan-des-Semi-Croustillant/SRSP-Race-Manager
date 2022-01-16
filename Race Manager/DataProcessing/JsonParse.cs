using Newtonsoft.Json;
using Race_Manager.Communication;

namespace Race_Manager.DataProcessing
{
    public class JsonParse
    {
        public static dynamic GameIdJsonDeserialize(string data)
        {
            return JsonConvert.DeserializeObject(data);
        }
        public static string DataFormatting(IMessageType TypeMessage, long Id, long IdGame, string NMEA, long Boat)
        {
            var serialiseJsonInfo = new JsonInformation
            {
                TypeMessage = TypeMessage,
                Id = Id,
                IdGame = IdGame,
                NMEA = NMEA,
                Boat = Boat
            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
    }

    internal class GestionJson
    {
        public static void TraitementIMessageType()
        {
            JsonParse.GameIdJsonDeserialize(data);

        }
    }

    //public enum IMessageType
    //{
    //    CONNECTION,
    //    DISCONNECTION,
    //    INFO,
    //    BOATSELECT,
    //}

    class JsonInformation
    {
        public IMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
        public string? NMEA { get; set; }
        public long Boat { get; set; }

    }

    class EnvironmentInfo
    {
        public int IdPlayer { get; set; }

    }
}
