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
            var infoFile = System.Text.Json.JsonSerializer.Deserialize<BoatType>(dataFile);
            if (!BoatType.BoatTypesList.Contains(infoFile))
            {
                BoatType.BoatTypesList.Add(infoFile);
                _logger.log(LoggingLevel.INFO, "UpdateAllBoatTypesList", "New boat type added from file");
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
            //var DataBoat = new BoatType()
            //{
            //    Name = Name,
            //    HullLength = HullLength,
            //    OverallLength = OverallLength,
            //    HullWidth = HullWidth,
            //    OverallWidth = OverallWidth,
            //    Draft = Draft,
            //    AirDraft = AirDraft,
            //    Weight = Weight,
            //    Polar = polar
            //};
            string pathFile = pathDataBoat + DataBoat.Name + "_" + DataBoat.ID + ".json";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(DataBoat);
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, jsonString);
            UpdateJsonData();
        }
    }
}
