using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Xml;


namespace RaceManager.Lecture
{
    public class TypeBateau
    {

        public int IDTypeBateau { get; set; }
        public string NomDuBateau { get; set; }
        public float LongueurCoque { get; set; }
        public float LongueurHorsTout { get; set; }
        public float LargeurCoque { get; set; }
        public float LargeurHorsTout { get; set; }
        public float TirantEeau { get; set; }
        public float TirantAir { get; set; }
        public float Poids { get; set; }

        public Polaire polaire = new Polaire();



    }
}