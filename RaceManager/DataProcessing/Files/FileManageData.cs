﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RaceManager.DataProcessing.Json;
using RaceManager.Reading;
using System.Text;

namespace RaceManager.DataProcessing.Files
{
    public partial class FileManageData
    {
        /// <summary>
        /// Reads the data from all directory, creation of index listing all files of this directory
        /// </summary>
        public static void UpdateJsonData()
        {

            _logger.log(LoggingLevel.DEBUG,"UploadJsonData()", pathJsonData);
            File.Create(pathJsonData).Close();
            string[] filesBoat = Directory.GetFiles(pathDataBoat);
            string[] filesPol = Directory.GetFiles(pathDataPol);
            //string[] filesRace = Directory.GetFiles(pathDataRace);

            List<JsonDataBoatList> listBoat = new List<JsonDataBoatList>();
            List<JsonDataPolList> listPol = new List<JsonDataPolList>();
            //List<JsonDataRaceList> listRace = new List<JsonDataRaceList>();

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
                dynamic forConstruction = JsonConvert.DeserializeObject<BoatType>(File.ReadAllText(filesBoat[i]));
                var boatListConstruction = new JsonDataBoatList
                {
                    BoatName = forConstruction.Name,
                    BoatId = forConstruction.ID,
                    BoatPath = "./index/boat/" + fileExt,
                    BoatInformation = forConstruction
                };
                listBoat.Add(boatListConstruction);
            }
            for (int i = 0; i < filesPol.Length; i++)
            {
                string file = Path.GetFileNameWithoutExtension(filesPol[i]);
                string fileExt = Path.GetFileName(filesPol[i]);
                string[] nameFile = file.Split("_");
                var polListConstruction = new JsonDataPolList
                {
                    PolName = nameFile[0],
                    PolId = Int64.Parse(nameFile[1]),
                    PolPath = "./index/pol/" + fileExt,
                    PolInformation = File.ReadAllText(filesPol[i])
                };
                listPol.Add(polListConstruction);
            }
            
            //Not use but implemented for futur race
            //for (int i = 0; i < filesRace.Length; i++)
            //{
            //    string file = Path.GetFileNameWithoutExtension(filesRace[i]);
            //    string fileExt = Path.GetFileName(filesRace[i]);
            //    string[] nameFile = file.Split("_");
            //    var boatListConstruction = new JsonDataRaceList
            //    {
            //        RaceName = nameFile[0],
            //        RaceId = Int32.Parse(nameFile[1]),
            //        RacePath = "./index/race/" + fileExt
            //    };
            //    listRace.Add(boatListConstruction);
            //}

            var dataConstruction = new JsonData
            {
                Data = new JsonDataNumber
                {
                    NumberBoat = filesBoat.Length,
                    NumberPol = filesPol.Length,
                    //NumberRace = filesRace.Length
                },

                Boat = new JsonDataBoat
                {
                    Information = "List Boat",
                    ListBoat = listBoat
                },
                
                Pol = new JsonDataPol
                {
                    Information = "List Pol",
                    ListPol = listPol
                }
            };

            string jsonString = JsonConvert.SerializeObject(dataConstruction);
            WriteInFile.WriteFilePath(pathJsonData, jsonString);
        }
    }
}
