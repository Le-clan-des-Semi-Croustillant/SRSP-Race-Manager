using Communication.DataProcessing.Json;

namespace Communication.DataProcessing.Files
{
    /// <summary>
    /// Management of boat to add him to BoatTypesList <see cref="BoatType"/>
    /// </summary>
    public partial class FileManageData
    {
        /// <summary>
        /// Save boat of a <see cref="BoatType"/> on spécific json file
        /// </summary>
        /// <param name="DataBoat"> all information of boat</param>
        public static void CreateBoatJson(BoatType DataBoat)
        {
            string pathFile = pathDataBoat + DataBoat.Name + "_" + DataBoat.ID + ".json";
            string jsonString = JsonConvert.SerializeObject(DataBoat);
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, jsonString);
        }
    }
}
