using RaceManager.DataProcessing;
using RaceManager.Communication;

namespace RaceManager.DataProcessing.Json
{
    public class JsonManage
    {

        public static void JsonType(string data)
        {
            dynamic informationJson = JsonParse.JsonDeserialize(data);
            Console.WriteLine(informationJson);
            try
            {

            }
            catch (Exception ex)
            {

            }

            switch (informationJson.IMessageType)
            {
                case 0:

                case 1:

                case 2:

                case 3:

                case 4: //Retourner une liste de bateau
                    Console.WriteLine(informationJson.IMessageType + "BOATLISTREQUEST");
                    string OutMessage = JsonParse.JsonSerialiseOBoatList();
                    //Envoyer à la personne qui m'as envoyé ma demande
                    break;

                case 5:

                default:
                    break;
            }
        }
    }
}