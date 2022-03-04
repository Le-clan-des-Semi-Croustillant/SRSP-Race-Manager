namespace RaceManager.Lecture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    using System.Xml;
    namespace XMLReadAndParse
    {
        public class GPXLoader
        {
            public List<List<string>> Gpx()
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
                return waypoints_info;
            }

            public string[] BateauAutorise()
            {
                XmlDocument xmlDocument = new XmlDocument();
                string TypeBateau;
                //Lire le fichier XML
                string test = "";
                xmlDocument.Load("D:\\course.xml");
                string[] tab = new string[1];
                //Créer une liste de nœuds XML avec l'expression XPath
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/bats/bat");
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    TypeBateau = xmlNode["typebateau"].InnerText;

                    tab[0] = (xmlNode["typebateau"].InnerText);
                    return tab;
                }
                return tab;
            }

            public string[] CaracteristiqueJauge()
            {
                XmlDocument xmlDocument = new XmlDocument();
                string TypeBateau;
                string LongueurCoque;
                string LongueurHorsTout;
                //Lire le fichier XML
                string test = "";
                xmlDocument.Load("D:\\imoca.xml");
                string[] tab = new string[8];
                //Créer une liste de nœuds XML avec l'expression XPath
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/bats/bat");



                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    TypeBateau = xmlNode["TypeBateau"].InnerText;
                    LongueurCoque = xmlNode["LongueurCoque"].InnerText;
                    LongueurHorsTout = xmlNode["LongueurHorsTout"].InnerText;
                    string LargeurCoque = xmlNode["LargeurCoque"].InnerText;
                    string LargeurHorsTout = xmlNode["LargeurHorsTout"].InnerText;
                    string TirantEeau = xmlNode["TirantEeau"].InnerText;
                    string TirantAir = xmlNode["TirantAir"].InnerText;
                    string Poids = xmlNode["Poids"].InnerText;
                    tab[0] = (xmlNode["TypeBateau"].InnerText);
                    tab[1] = (xmlNode["LongueurCoque"].InnerText);
                    tab[2] = (xmlNode["LongueurHorsTout"].InnerText);
                    tab[3] = (LargeurCoque);
                    tab[4] = (LargeurHorsTout);
                    tab[5] = (TirantEeau);
                    tab[6] = (TirantAir);
                    tab[7] = (Poids);
                    return tab;
                }
                return tab;
            }



        }
    }
}
