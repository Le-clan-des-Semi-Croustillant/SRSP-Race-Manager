using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Text;
using System.Xml;




namespace Communication.DataProcessing.Json 
{
    public partial class BoatType
    {
        // <summary>
        // Initializes a new instance of the BoatType class.
        // </summary>
        public Int64 ID { get; } = random.NextInt64();
        public string Name { get; set; }
        public float HullLength { get; set; }
        public float OverallLength { get; set; }
        public float HullWidth { get; set; }
        public float OverallWidth { get; set; }
        public float Draft { get; set; }
        public float AirDraft { get; set; }
        public float Weight { get; set; }
        //public Polar Polar = new Polar();
        public List<Polar> Polar { get; set; }

        static private System.Random random = new System.Random(DateTime.Now.Millisecond);

        public static List<BoatType> BoatTypesList = new();
        public BoatType()
        {
            //Name = $"Boat {BoatTypesList.Count}";
            Name = "Unnamed Boat";
        }


        public override bool Equals(Object o)
        {
            if (o.GetType() == this.GetType())
                return ((BoatType)o).ID.Equals(ID);
                //return ((BoatType)o).Name.Equals(Name);

            return false;
        }
    }
}