using RaceManager.DataProcessing;
using RaceManager.Communication;

namespace RaceManager.DataProcessing.Json
{
    public class JsonManage
    {

        public static string JsonType(string data)
        {
            dynamic informationJson = JsonParse.JsonDeserialize(data);
            Console.WriteLine(informationJson);
            try
            {

            }
            catch (Exception ex)
            {

            }
            string OutMessage;
            switch ((IMessageType)informationJson.IMessageType)
            {
               
                case IMessageType.CONNECTION:
                    Console.WriteLine(informationJson.IMessageType + "CONNECTION");
                    OutMessage = JsonParse.JsonSerialiseOConnection();
                    break;
                case IMessageType.DISCONNECTION:
                    Console.WriteLine(informationJson.IMessageType + "DISCONNECTION");
                    OutMessage = JsonParse.JsonSerialiseODisconnection();
                    break;
                case IMessageType.PLAYERINFO:
                    Console.WriteLine(informationJson.PLAYERINFO + "PLAYERINFO");
                    OutMessage = "PLAYERINFO";
                    break;
                case IMessageType.BOATSELECT:
                    Console.WriteLine(informationJson.PLAYERINFO + "BOATSELECT");
                    OutMessage = "BOATSELECT";
                    break;
                case IMessageType.BOATLISTREQUEST: //Retourner une liste de bateau
                    Console.WriteLine(informationJson.IMessageType + "BOATLISTREQUEST");
                    OutMessage = JsonParse.JsonSerialiseOBoatList();
                    //Envoyer à la personne qui m'as envoyé ma demande
                    break;

                case IMessageType.ENDRACE:
                    Console.WriteLine(informationJson.PLAYERINFO + "ENDRACE");
                    OutMessage = JsonParse.JsonSerialiseOEndRace();
                    break;

                default:
                    OutMessage = "Error";
                    break;
            }
            return OutMessage;
        }
    }
}