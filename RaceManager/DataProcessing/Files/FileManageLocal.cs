namespace RaceManager.DataProcessing.Files
{
    /// <summary>
    /// Management of files and folders of the race manager to save information locally
    /// </summary>
    
    public partial class FileManageData
    {

        public static string currentDirectory = Directory.GetCurrentDirectory();
        public static string pathData = currentDirectory + Path.DirectorySeparatorChar + "dataResources" + Path.DirectorySeparatorChar;
        public static string pathDataBoat = pathData + "boat" + Path.DirectorySeparatorChar;
        public static string pathDataPol = pathData + "pol" + Path.DirectorySeparatorChar;
        public static string pathDataRace = pathData + "race" + Path.DirectorySeparatorChar;
        public static string pathJsonData = pathData + "data.json";
        
        /// <summary>
        /// Check if directory used by Race Manager exist and create him if don't exist
        /// </summary>
        public static void CheckFilesFolderData()
        {
            Console.WriteLine(currentDirectory);
            Console.WriteLine(pathData);
            Console.WriteLine(pathDataBoat);
            Console.WriteLine(pathDataPol);
            Console.WriteLine(pathDataRace);
            CheckDirectory(pathData);
            CheckDirectory(pathDataBoat);
            CheckDirectory(pathDataPol);
            CheckDirectory(pathDataRace);

            UpdateJsonData();
        }

        /// <summary>
        /// Delete local file with specific path file and update data.json, he is a index of all pol and boat files
        /// </summary>
        /// <param name="path"> complete path of file you want to delete</param>
        public static void DeleteFile(string path)
        {
            File.Delete(path);
            UpdateJsonData();
        }

        class WriteInFile
        {
            /// <summary>
            /// Write data on file
            /// </summary>
            /// <param name="path"> complete path of file you want to write on him</param>
            /// <param name="message"> data you want write on file</param>
            public static void WriteFilePath(string path, dynamic message)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
        /// <summary>
        /// Check if specific directory exist
        /// </summary>
        /// <param name="path"> complete path of directory </param>
        public static void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                CreateDirectory(path);
            }
        }

        /// <summary>
        /// Creation of directory
        /// </summary>
        /// <param name="path"> complete path of directory </param>
        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
