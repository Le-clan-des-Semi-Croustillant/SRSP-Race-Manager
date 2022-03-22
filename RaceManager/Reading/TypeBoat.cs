using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Xml;


namespace RaceManager.Reading
{
    public class TypeBoat
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public float HullLength { get; set; }
        public float OverallLength { get; set; }
        public float HullWidth { get; set; }
        public float OverallWidth { get; set; }
        public float Draft { get; set; }
        public float AirDraft { get; set; }
        public float Weight { get; set; }

        public Polaire polaire = new Polaire();



    }
}