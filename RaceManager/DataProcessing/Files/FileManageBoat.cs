using Newtonsoft.Json;
using RaceManager.Reading;

namespace RaceManager.DataProcessing.Files
{
    /// <summary>
    /// Management of boat to add him to BoatTypesList <see cref="BoatType"/>
    /// </summary>
    public partial class FileManageData
    {
        //private static RMLogger _logger = new(LoggingLevel.DEBUG, "FileManageData");

        public static void ChargeBoatListInClass()
        {

        }

        private static RMLogger _logger = new(LoggingLevel.INFO, "FileManageData");
        /// <summary>
        /// Add to BoatTypesList all boat already exist on local file
        /// </summary>
        public static void UpdateAllBoatTypesList()
        {
            string[] filesBoat = Directory.GetFiles(pathDataBoat);

            for (int i = 0; i < filesBoat.Length; i++)
            {
                UpdateBoatTypesList(filesBoat[i]);
            }
        }

        /// <summary>
        /// Add to BoatTypesList boat already exist on local file
        /// </summary>
        /// <param name="path"> complete path of file you want to read</param>
        public static void UpdateBoatTypesList(string path)
        {
            string dataFile = File.ReadAllText(path);
            
            _logger.log(LoggingLevel.DEBUG, "UpdateBoatTypesList()", $"Read file {path} : " + dataFile);
            try
            {
                var infoFile = JsonConvert.DeserializeObject<BoatType>(dataFile);

                if (!BoatType.BoatTypesList.Contains(infoFile))
                {
                    BoatType.BoatTypesList.Add(infoFile);
                    _logger.log(LoggingLevel.INFO, "UpdateAllBoatTypesList", "New boat type added from file");
                }
            }
            catch (System.Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "UpdateAllBoatTypesList", $"Error during read file {path} : " + e.Message);
            }
        }

        /// <summary>
        /// Save all boat on file of <see cref="BoatType"/>
        /// </summary>
        public static void ReadBoatTypesList()
        {
            foreach (var boatType in BoatType.BoatTypesList)
            {
                CreateBoatJson(boatType);
            }
        }

        //public static void CreateBoatJson(int ID, string Name,
        //    float HullLength, float OverallLength, float HullWidth,
        //    float OverallWidth, float Draft, float AirDraft, float Weight, Polar polar)
        /// <summary>
        /// Save boat of a <see cref="BoatType"/> on spécific json file
        /// </summary>
        /// <param name="DataBoat"> all information of boat</param>
        public static void CreateBoatJson(BoatType DataBoat)
        {
            //Si l'id existe déjà il faut remplacer le fichier
            string pathFile = pathDataBoat + DataBoat.Name + "_" + DataBoat.ID + ".json";
            string jsonString = JsonConvert.SerializeObject(DataBoat);
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, jsonString);
            UpdateJsonData();
        }
    }
}
