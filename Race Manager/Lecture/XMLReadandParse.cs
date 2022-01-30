namespace RaceManager.Lecture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;

    namespace XMLReadAndParse
    {
        public class GPXLoader
        {

            static void Main(string[] args)
            {

                List<List<string>> waypoints_info = new List<List<string>>();
                var xdoc = XDocument.Load("D:\\Point de départs.gpx");
                XNamespace ns = "http://www.topografix.com/GPX/1/1";
                var test = from wpt in xdoc.Descendants(ns + "wpt")
                           select new
                           {
                               Lon = wpt.Attribute("lon").Value,
                               Lat = wpt.Attribute("lat").Value,
                               Name = wpt.Element(ns + "name").Value
                           };
                foreach (var name in test)
                {
                    var waypoints = new List<string> { };
                    waypoints.Add(name.Name);
                    waypoints.Add(name.Lon);
                    waypoints.Add(name.Lat);
                    waypoints_info.Add(waypoints);
                }

                foreach (var name in waypoints_info)
                {
                    foreach (String s1 in name)
                    {
                        Console.WriteLine(s1);
                    }
                    Console.WriteLine("\n");

                }

            }
        }
    }
}
