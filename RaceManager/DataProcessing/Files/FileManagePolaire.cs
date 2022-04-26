namespace RaceManager.DataProcessing.Files
{
    public partial class FileManageData
    {
        public static string CreateFilePolaire(string Name, int ID, string data)
        {
            string pathFile = pathDataPol + Name + "_" + ID + ".pol";
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, data);
            UpdateJsonData();
            return pathFile;
        }
    }
}
