using Newtonsoft.Json;
using RaceManager.Communication;
using RaceManager.DataProcessing;
using RaceManager.DataProcessing.Json;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

// See https://aka.ms/new-console-template for more information

class ProgrammeServer
{

    public static void GetLanguages()
    {
        // Gets the list of installed languages.
        CultureInfo ci = CultureInfo.InstalledUICulture;

        Console.WriteLine("Default Language Info:");
        Console.WriteLine("* Name: {0}", ci.Name);
        Console.WriteLine("* Display Name: {0}", ci.DisplayName);
        Console.WriteLine("* English Name: {0}", ci.EnglishName);
        Console.WriteLine("* 2-letter ISO Name: {0}", ci.TwoLetterISOLanguageName);
        Console.WriteLine("* 3-letter ISO Name: {0}", ci.ThreeLetterISOLanguageName);
        Console.WriteLine("* 3-letter Win32 API Name: {0}", ci.ThreeLetterWindowsLanguageName);

    }


    public static int Main(String[] args)
    {
        Console.WriteLine("Hello, World!");
        GetLanguages();

        //string xml = @"<?xml version='1.0' standalone='no'?><root><person id='1'><name>Alan</name><url>http://www.google.com</url></person><person id='2'><name>Louis</name><url>http://www.yahoo.com</url></person></root>";

        XmlDocument doc = new XmlDocument();
        doc.Load(@"C:\Users\Sky\Documents\GitHub\LCSC-dev\SRSP-Race-Manager\consoleTests\Point_de_departs.gpx");
        string text = File.ReadAllText(@"C:\Users\Sky\Documents\GitHub\LCSC-dev\SRSP-Race-Manager\consoleTests\Point_de_departs.gpx");
        string json = JsonConvert.SerializeXmlNode(doc);

        Console.WriteLine(json);

        XDocument doc2 = XDocument.Parse(text);
        Console.WriteLine(doc2);
        //Console.WriteLine(doc2.wpt);
        //IMessageType TypeMessage = 0;
        //long Id = 4242;
        //long IdGame = 01;
        //string NMEA = "YOLO";
        //long Boat = 0;
        //int IdPlayer = 123;
        //string NamePlayer = "Sky";

        //string test = JsonParse.JsonSerialiseConnection(TypeMessage, Id, IdGame, NMEA, Boat, IdPlayer, NamePlayer);
        //Console.WriteLine("test" + test);

        //JsonManage.JsonType(test);

        //string[] str = new string[] { "a", "b" };

        //AsyncServer.Port = 45678;
        //AsyncServer.Run();


        Console.WriteLine();
        return 0;
    }
}