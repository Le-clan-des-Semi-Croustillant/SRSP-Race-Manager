namespace Communication.DataProcessing.Files
{
    /// <summary>
    /// Management of files and folders of the race manager to save information locally
    /// </summary>
    
    public partial class FileManageData
    {

        public static string currentDirectory = Directory.GetCurrentDirectory();
        public static string pathData = currentDirectory + Path.DirectorySeparatorChar + "index_SimulateurSimple" + Path.DirectorySeparatorChar;
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
        }

        /// <summary>
        /// Delete local file with specific path file and update data.json, he is a index of all pol and boat files
        /// </summary>
        /// <param name="path"> complete path of file you want to delete</param>
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public class WriteInFile
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

            //For write on file .pol exemple
            //string machin = $"TWA\\TWS;0;2;4;6;8;10;12;14;16;18;20;22;24;26;28;30;35;40;50;60;70\r\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0\r\n30;0;1.906;3.711;5.216;6.219;6.319;7.021;7.322;7.422;7.522;7.603;7.703;7.803;7.904;7.904;8.004;8.004;8.004;7.874;7.071;6.289\r\n35;0;2.207;4.614;6.419;7.623;7.723;8.726;8.927;9.127;9.228;9.388;9.488;9.679;9.779;9.779;9.88;9.98;9.98;9.809;8.786;7.793\r\n40;0;2.808;5.617;7.823;9.228;9.528;10.632;10.933;11.133;11.334;11.464;11.655;11.755;11.855;11.956;12.056;12.156;12.156;11.946;10.692;9.569\r\n45;0;3.109;6.219;8.525;9.829;10.03;11.033;11.434;11.735;12.036;12.056;12.247;12.347;12.548;12.648;12.748;12.939;12.939;12.728;11.364;10.14\r\n50;0;3.31;6.72;9.027;9.829;10.431;11.434;11.936;12.237;12.537;12.648;12.848;13.039;13.24;13.34;13.631;13.932;13.932;13.701;12.227;10.983\r\n55;0;3.51;7.222;9.528;10.03;10.832;11.936;12.237;12.738;13.039;13.139;13.34;13.731;13.932;14.132;14.423;14.915;14.915;14.674;13.079;11.735\r\n60;0;3.711;7.522;9.93;10.431;11.133;12.237;12.738;13.139;13.44;13.631;13.932;14.223;14.523;14.915;15.216;15.908;15.908;15.637;13.942;12.487\r\n65;0;3.892;7.673;10.17;10.762;11.364;12.457;13.059;13.46;13.952;14.263;14.724;15.115;15.506;15.908;16.299;17.292;17.292;17.001;15.185;13.611\r\n70;0;4.072;7.944;10.331;10.923;11.615;12.909;13.31;13.902;14.403;14.985;15.416;16.008;16.399;16.991;17.392;18.776;18.776;18.455;16.519;14.734\r\n75;0;4.172;8.044;10.521;11.324;11.916;13.162;13.967;14.589;15.295;15.888;16.481;16.932;17.535;18.037;18.64;20.154;19.759;19.428;17.382;15.486\r\n80;0;4.273;8.245;10.622;11.916;12.116;13.416;14.441;15.386;16.106;16.815;17.42;18.025;18.599;19.214;19.934;21.582;20.752;20.401;18.245;16.329\r\n85;0;4.273;8.245;10.722;12.116;12.608;13.608;14.749;15.803;16.732;17.639;18.348;19.152;19.851;20.341;20.956;22.396;21.534;21.183;18.907;16.891\r\n90;0;4.273;8.245;10.722;12.217;13.009;14.013;15.149;16.21;17.347;18.369;19.277;20.184;20.789;21.374;21.885;23.22;22.327;21.956;19.669;17.552\r\n95;0;4.172;8.044;10.622;12.116;13.21;14.215;15.457;16.836;17.973;19.089;19.892;20.696;21.301;21.686;21.989;23.731;22.126;21.765;19.478;17.362\r\n100;0;4.072;7.944;10.331;11.916;13.31;14.316;15.663;17.243;18.484;19.705;20.518;21.321;21.707;21.999;22.291;23.835;22.126;21.765;19.478;17.362\r\n105;0;3.872;7.643;10.231;12.016;13.21;14.417;15.766;17.451;18.693;20.017;20.612;21.321;21.812;22.312;22.709;24.044;22.919;22.537;20.15;18.024\r\n110;0;3.681;7.452;10.231;12.116;13.009;14.417;15.858;17.764;19.11;20.33;20.716;21.321;21.812;22.511;23.22;24.764;23.811;23.41;20.913;18.676\r\n115;0;3.611;7.422;10.19;11.916;13.009;14.316;15.961;17.764;19.006;20.226;20.821;21.624;22.323;23.032;23.825;25.588;24.604;24.192;21.585;19.338\r\n120;0;3.611;7.222;10.03;11.936;13.22;14.215;15.961;17.764;18.901;20.122;21.029;21.937;22.844;23.648;24.44;26.307;25.296;24.874;22.257;19.9\r\n125;0;3.41;6.82;9.729;11.635;13.039;14.357;16.217;17.764;18.901;20.122;21.134;22.041;23.053;23.95;24.858;27.027;25.988;25.546;22.828;20.371\r\n130;0;3.31;6.519;9.228;11.234;12.738;14.357;16.228;17.942;19.089;20.122;21.238;22.25;23.355;24.263;25.264;27.643;26.579;26.128;23.3;20.832\r\n135;0;3.009;5.918;8.626;10.632;12.136;13.649;15.611;17.524;18.672;20.268;21.426;22.552;23.564;24.565;25.577;28.592;27.562;27.101;24.263;21.685\r\n140;0;2.808;5.516;8.024;10.03;11.635;13.042;14.79;17.107;18.255;20.341;21.478;22.709;23.731;24.764;25.786;29.802;28.656;28.174;25.215;22.527\r\n145;0;2.407;5.015;7.222;9.127;10.832;12.233;13.763;15.751;17.211;19.11;20.758;22.5;23.94;25.17;26.401;29.593;28.455;27.984;25.025;22.337\r\n150;0;2.207;4.413;6.519;8.525;10.13;11.526;13.044;14.604;16.273;18.088;20.143;22.291;24.044;25.588;27.121;29.385;28.255;27.783;24.834;22.146\r\n155;0;2.006;4.012;5.817;7.723;9.228;10.818;12.222;13.665;15.125;16.544;18.39;20.341;22.198;23.731;25.483;28.978;27.863;27.392;24.453;21.865\r\n160;0;1.805;3.51;5.316;7.021;8.626;10.11;11.503;12.935;14.186;15.104;16.951;18.807;20.549;22.291;23.94;28.456;27.362;26.91;24.062;21.494\r\n170;0;1.605;3.31;5.015;6.62;8.024;9.328;10.431;11.635;12.738;13.631;15.216;16.7;18.375;19.859;21.434;25.386;25.386;24.363;22.347;19.9\r\n180;0;1.504;3.21;4.714;6.319;7.723;8.927;10.03;11.133;12.136;13.039;14.523;16.108;17.583;19.167;20.551;24.503;24.503;21.855;21.063;19.238\r\n";
            //string path = @"C:\Users\Sky\Documents\GitHub\LCSC-dev\SRSP-Race-Manager\RaceManager\bin\Release\net6.0\test.txt";
            //WriteFilePath(path, machin);
        }

        public static string ReadFilePath(string path)
        {
            string data = "";
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    data = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return data;
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
