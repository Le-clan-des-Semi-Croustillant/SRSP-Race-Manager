using Communication.DataProcessing.Json;
using Newtonsoft.Json;

namespace Communication.DataProcessing.Files
{
    public partial class FileManageData
    {

        public static void SaveData(dynamic response)
        {
            FileManageData.CheckFilesFolderData();

            dynamic jsonData = JsonConvert.DeserializeObject<JsonData>(response);
            Console.WriteLine("NumberBoat : " + jsonData.Data.NumberBoat);
            Console.WriteLine("NumberPol : " + jsonData.Data.NumberPol);

            for (int i = 0; i < jsonData.Data.NumberBoat; i++)
            {
                Console.WriteLine("Boat " + i + " Name : " + jsonData.Boat.ListBoat[i].BoatName);
                Console.WriteLine("Boat " + i + " ID : " + jsonData.Boat.ListBoat[i].BoatId);
                Console.WriteLine("Boat " + i + " Information : " + jsonData.Boat.ListBoat[i].BoatInformation);
                FileManageData.CreateBoatJson(jsonData.Boat.ListBoat[i].BoatInformation);
            }

            for (int i = 0; i < jsonData.Data.NumberPol; i++)
            {
                Console.WriteLine("Pol " + i + " Name : " + jsonData.Pol.ListPol[i].PolName);
                Console.WriteLine("Pol " + i + " ID : " + jsonData.Pol.ListPol[i].PolId);
                Console.WriteLine("Pol " + i + " Information : " + jsonData.Pol.ListPol[i].PolInformation);
                FileManageData.CreateFilePolaire(jsonData.Pol.ListPol[i].PolName, jsonData.Pol.ListPol[i].PolId, jsonData.Pol.ListPol[i].PolInformation);
            }
        }
        
    }
}
