using Newtonsoft.Json;
using Race_Manager.Communication;

namespace Race_Manager.DataProcessing.Json
{
    public class JsonParse
    {
        public static dynamic JsonDeserialize(string data)
        {
            return JsonConvert.DeserializeObject(data);
        }
        public static string JsonSerialiseConnection(IMessageType TypeMessage, long Id, long IdGame, string NMEA, long Boat, int IdPlayer, string NamePlayer)
        {
            var serialiseJsonInfo = new JsonInformationConnection
            {
                TypeMessage = TypeMessage,
                Id = Id,
                IdGame = IdGame,
                NMEA = NMEA,
                Boat = Boat,
                EnvironmentInfos = new EnvironmentInfo
                {
                    IdPlayer = IdPlayer,
                    NamePlayer = NamePlayer
                }

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }

        public static string JsonSerialiseDisconnection(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonInformationDisconnection
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }

        public static string JsonSerialiseInfo(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonInformationInfo
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseBoatSelect(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonInformationBoatSelect
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
    }

    class JsonInformationConnection
    {
        public IMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
        public string? NMEA { get; set; }
        public long Boat { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }

    class JsonInformationDisconnection
    {
        public IMessageType TypeMessage { get; set; }
    }

    class JsonInformationInfo
    {
        public IMessageType TypeMessage { get; set; }
    }

    class JsonInformationBoatSelect
    {
        public IMessageType TypeMessage { get; set; }
    }

    class EnvironmentInfo
    {
        public int IdPlayer { get; set; }
        public string? NamePlayer { get; set; }
    }
}