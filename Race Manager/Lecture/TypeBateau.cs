using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using RaceManager.Lecture.XMLReadAndParse;

namespace RaceManager.Lecture
{
    public class TypeBateau
    {

         public string NomDuBateau { get; set; }
         public float LongueurCoque { get; set; }
         public float LongueurHorsTout { get; set; }
         public float LargeurCoque { get; set; }
         public float LargeurHorsTout { get; set; }
         public float TirantEeau { get; set; }
         public float TirantAir { get; set; }
         public float Poids { get; set; }
         private GPXLoader caracteristiqueLecture = new GPXLoader();
         private string[] elementsDeBateau = new string[8];
         public Course course =new Course();
        public Polaire polaire = new Polaire();
        public void InitialisationDesDonnees()
         {
                elementsDeBateau = caracteristiqueLecture.CaracteristiqueJauge();
                NomDuBateau = elementsDeBateau[0];
                LongueurCoque = float.Parse(elementsDeBateau[1]); 
                LongueurHorsTout = float.Parse(elementsDeBateau[2]);
                LargeurCoque = float.Parse(elementsDeBateau[3]);
                LargeurHorsTout = float.Parse(elementsDeBateau[4]);
                TirantEeau = float.Parse(elementsDeBateau[5]);
                TirantAir = float.Parse(elementsDeBateau[6]);
                Poids = float.Parse(elementsDeBateau[7]);


         }
        

     }
}
