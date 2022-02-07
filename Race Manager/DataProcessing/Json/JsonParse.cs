using Newtonsoft.Json;
using RaceManager.Communication;

namespace RaceManager.DataProcessing.Json
{
    public class JsonParse
    {
        public static dynamic JsonDeserialize(string data)
        {
            return JsonConvert.DeserializeObject(data);
        }
        public static string JsonSerialiseConnection(IMessageType TypeMessage, long Id, long IdGame, string NMEA, string Boat, int IdPlayer, string NamePlayer)
        {
            var serialiseJsonInfo = new JsonTest
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

        public static string JsonSerialiseIConnection(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonIConnection
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseIDisconnection(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonIDisconnection
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseIPlayerInfo(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonIPlayerInfo
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseIBoatSelect(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonIBoatSelect
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseIEndRace(IMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonIEndRace
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }

        public static string JsonSerialiseOConnection()
        {
            OMessageType TypeMessage = OMessageType.CONNECTION;
            var serialiseJsonInfo = new JsonOConnection
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseODisconnection()
        {
            OMessageType TypeMessage = OMessageType.DISCONNECTION;
            var serialiseJsonInfo = new JsonODisconnection
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
        public static string JsonSerialiseOInitRace(OMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonOInitRace
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }

        public static string JsonSerialiseOEnvironmentInfo(OMessageType TypeMessage)
        {
            var serialiseJsonInfo = new JsonOEnvironmentInfo
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }

        public static string JsonSerialiseOBoatList()
        {
            OMessageType TypeMessage = OMessageType.BOATLIST;
            //Retourner liste des bateaux
            var serialiseJsonInfo = new JsonOBoatList
            {
                TypeMessage = TypeMessage,
                //Retourner liste des bateaux

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }

        public static string JsonSerialiseOEndRace()
        {
            OMessageType TypeMessage = OMessageType.ENDRACE;
            var serialiseJsonInfo = new JsonOEndRace
            {
                TypeMessage = TypeMessage,

            };
            return System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);
        }
    }

    class JsonTest
    {
        public IMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
        public string? NMEA { get; set; }
        public string? Boat { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }

    class JsonIConnection
    {
        public IMessageType TypeMessage { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }
    class JsonIDisconnection
    {
        public IMessageType TypeMessage { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }
    class JsonIPlayerInfo
    {
        public IMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
        public string? NMEA { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }
    class JsonIBoatSelect
    {
        public IMessageType TypeMessage { get; set; }
        //public BoatType Boat { get; set; }
    }

    class JsonIBoatListSelect
    {
        public IMessageType TypeMessage { get; set; }
        //public BoatType Boat { get; set; }
    }

    class JsonIEndRace
    {
        public IMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }

    class JsonOConnection
    {
        public OMessageType TypeMessage { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }
    class JsonODisconnection
    {
        public OMessageType TypeMessage { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }
    class JsonOInitRace
    {
        public OMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
    }
    class JsonOEnvironmentInfo
    {
        public OMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
    }
    class JsonOBoatList
    {
        public OMessageType TypeMessage { get; set; }
        //Retourner liste des bateaux
    }
    class JsonOEndRace
    {
        public OMessageType TypeMessage { get; set; }
        public long Id { get; set; }
        public long IdGame { get; set; }
        public EnvironmentInfo? EnvironmentInfos { get; set; }
    }

    class EnvironmentInfo
    {
        public int IdPlayer { get; set; }
        public string? NamePlayer { get; set; }
    }
}