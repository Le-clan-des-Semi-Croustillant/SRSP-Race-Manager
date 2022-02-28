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
            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //}
            string OutMessage;
            Console.WriteLine((IMessageType)informationJson.TypeMessage);
            switch ((IMessageType)informationJson.TypeMessage)
            {
               
                case IMessageType.CONNECTION:
                    Console.WriteLine(informationJson.TypeMessage + " Connection");
                    OutMessage = JsonParse.JsonSerialiseOConnection();
                    break;
                case IMessageType.DISCONNECTION:
                    Console.WriteLine(informationJson.TypeMessage + " Disconnection");
                    OutMessage = JsonParse.JsonSerialiseODisconnection();
                    break;
                case IMessageType.PLAYERINFO:
                    Console.WriteLine(informationJson.TypeMessage + " Player Info");
                    OutMessage = "Player Info";
                    break;
                case IMessageType.BOATSELECT:
                    Console.WriteLine(informationJson.TypeMessage + " Boat Select");
                    OutMessage = "Boat Select";
                    break;
                case IMessageType.BOATLISTREQUEST: //Retourner une liste de bateau
                    Console.WriteLine(informationJson.TypeMessage + " Boast List Request");
                    OutMessage = JsonParse.JsonSerialiseOBoatList();
                    //Envoyer à la personne qui m'as envoyé ma demande
                    break;
                case IMessageType.ENDRACE:
                    Console.WriteLine(informationJson.TypeMessage + " End Race");
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