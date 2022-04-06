using Communication.DataProcessing.Json;

namespace Communication.DataProcessing.Files
{
    public partial class FileManageData
    {
        public static void CreateFilePolaire(string Name, int ID, string DataPol)
        {
            string pathFile = pathDataPol + Name + "_" + ID.ToString() + ".pol";
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, DataPol);
        }
    }
}
