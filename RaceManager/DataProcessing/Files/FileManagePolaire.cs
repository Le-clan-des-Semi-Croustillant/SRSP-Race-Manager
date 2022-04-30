namespace RaceManager.DataProcessing.Files
{
    public partial class FileManageData
    {
        /// <summary>
        /// Creation of polar file
        /// </summary>
        /// <param name="Name">Name of the polar</param>
        /// <param name="ID">Id of the polar</param>
        /// <param name="data">Data to write on this file</param>
        /// <returns>Path of new file created</returns>
        public static string CreateFilePolaire(string Name, long ID, string data)
        {
            string pathFile = pathDataPol + Name + "_" + ID + ".pol";
            File.Create(pathFile).Close();
            WriteInFile.WriteFilePath(pathFile, data);
            UpdateJsonData();
            return pathFile;
        }
    }
}
