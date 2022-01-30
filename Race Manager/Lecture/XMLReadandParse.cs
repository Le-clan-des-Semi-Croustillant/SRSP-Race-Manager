namespace RaceManager.Lecture
{
    using System;
    using System.Xml;

    namespace XMLReadAndParse
    {
        class XMLReadandParse
        {
            static void Main(string[] args)
            {

                using (XmlReader reader = XmlReader.Create("D:\\Point de départs.gpx"))
                {
                    int numeroWaypoint = 1;

                    while (reader.Read())
                    {

                        if (reader.IsStartElement())
                        {


                            switch (reader.Name.ToString())
                            {

                                case "name":

                                    Console.WriteLine("Voici le waypoint numero " + numeroWaypoint + " rencontrer et voisin son nom : " + reader.ReadString() + "\n");
                                    numeroWaypoint += 1;

                                    break;
                                case "wpt":

                                    Console.WriteLine("Ma longitude et latitude est " + reader.ReadString());
                                    break;
                            }
                        }



                    }
                }
                Console.ReadKey();
            }
        }
    }
}
