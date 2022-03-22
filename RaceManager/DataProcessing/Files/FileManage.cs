using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RaceManager.DataProcessing.Json;
using RaceManager.Reading;

namespace RaceManager.DataProcessing.Files
{
    public class FileManage
    {
        public static string currentDirectory = Directory.GetCurrentDirectory();
        public static string pathData = currentDirectory + "\\dataResources\\";
        public static string pathDataBoat = pathData + "boat\\";
        public static string pathDataPol = pathData + "pol\\";
        public static string pathDataRace = pathData + "race\\";
        public static string pathJsonData = pathData + "data.json";

        public static void CheckFilesFolderData()
        {
            CheckDirectory(pathData);
            CheckDirectory(pathDataBoat);
            CheckDirectory(pathDataPol);
            CheckDirectory(pathDataRace);

            UpdateJsonData();
        }

        public static void UpdateJsonData()
        {
            Console.WriteLine(pathJsonData);
            File.Create(pathJsonData).Close();
            string[] filesBoat = Directory.GetFiles(pathDataBoat);
            string[] filesPol = Directory.GetFiles(pathDataPol);
            string[] filesRace = Directory.GetFiles(pathDataRace);

            List<JsonDataBoatList> listBoat = new List<JsonDataBoatList>();
            List<JsonDataPolList> listPol = new List<JsonDataPolList>();
            List<JsonDataRaceList> listRace = new List<JsonDataRaceList>();

            for (int i = 0; i < filesBoat.Length; i++)
            {
                //string dataFile = File.ReadAllText(filesBoat[i]);
                //if (!string.IsNullOrWhiteSpace(dataFile))
                //{
                //    dataFile = dataFile.Trim();
                //    if ((dataFile.StartsWith("{ ") && dataFile.EndsWith("}")) || (dataFile.StartsWith("[") && dataFile.EndsWith("]")))
                //    {
                //        try
                //        {
                //            var obj = JToken.Parse(dataFile);
                //        }
                //        catch (JsonReaderException jex)
                //        {
                //            //Exception in parsing json
                //            Console.WriteLine(jex.Message);
                //        }
                //        catch (Exception ex) //some other exception
                //        {
                //            Console.WriteLine(ex.ToString());
                //        }
                //    }
                //}
               
                string file = Path.GetFileNameWithoutExtension(filesBoat[i]);
                string fileExt = Path.GetFileName(filesBoat[i]);
                string[] nameFile = file.Split("_");
                var boatListConstruction = new JsonDataBoatList
                {
                    BoatName = nameFile[0],
                    BoatId = Int32.Parse(nameFile[1]),
                    BoatPath = "/data/boat/" + fileExt
                };
                listBoat.Add(boatListConstruction);
            }
            for (int i = 0; i < filesPol.Length; i++)
            {
                string file = Path.GetFileNameWithoutExtension(filesBoat[i]);
                string fileExt = Path.GetFileName(filesBoat[i]);
                string[] nameFile = file.Split("_");
                var polListConstruction = new JsonDataPolList
                {
                    PolName = nameFile[0],
                    PolId = Int32.Parse(nameFile[1]),
                    PolPath = "/data/pol/" + fileExt
                };
                listPol.Add(polListConstruction);
            }
            for (int i = 0; i < filesRace.Length; i++)
            {
                string file = Path.GetFileNameWithoutExtension(filesBoat[i]);
                string fileExt = Path.GetFileName(filesBoat[i]);
                string[] nameFile = file.Split("_");
                var boatListConstruction = new JsonDataRaceList
                {
                    RaceName = nameFile[0],
                    RaceId = Int32.Parse(nameFile[1]),
                    RacePath = "/data/race/" + fileExt
                };
                listRace.Add(boatListConstruction);
            }

            var dataConstruction = new JsonData
            {
                Data = new JsonDataNumber
                {
                    NumberBoat = filesBoat.Length,
                    NumberPol = filesRace.Length,
                    NumberRace = filesRace.Length
                },

                Boat = new JsonDataBoat
                {
                    Information = "List Boat",
                    ListBoat = listBoat
                }
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(dataConstruction);
            WriteInFile.WriteFilePath(pathJsonData, jsonString);

        }

        public static void CreateBoatJson(int ID, string Name,
            float HullLength, float OverallLength, float HullWidth,
            float OverallWidth, float Draft, float AirDraft, float Weight, Polaire polaire)
        {
            var DataBoat = new TypeBoat
            {
                ID = ID,
                Name = Name,
                HullLength = HullLength,
                OverallLength = OverallLength,
                HullWidth = HullWidth,
                OverallWidth = OverallWidth,
                Draft = Draft,
                AirDraft = AirDraft,
                Weight = Weight,
                polaire = polaire
            };
            string pathFile = pathDataBoat + Name + "_" + ID + ".json";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(DataBoat);
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, jsonString);
            UpdateJsonData();
        }

        public static void CreateFilePolaire(string Name, int ID, string data)
        {
            string pathFile = pathDataPol + Name + "_" + ID + ".pol";
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, data);
            UpdateJsonData();
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
            UpdateJsonData();
        }

        class WriteInFile
        {
            public static void WriteFilePath(string path, dynamic message)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(message);
                        sw.Close();
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        public static void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                CreateDirectory(path);
            }
        }

        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
