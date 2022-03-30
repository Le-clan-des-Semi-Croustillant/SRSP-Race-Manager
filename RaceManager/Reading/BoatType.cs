using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using RaceManager.Language;




namespace RaceManager.Reading
{
    public partial class BoatType : IEquatable<BoatType>, IComparable<BoatType>
    {
        private static RMLogger logger = new();
        public static List<BoatType> BoatTypesList = new();
        
        /// <summary>
        /// Initializes a new instance of the BoatType class.
        /// </summary>
        public Int64 ID { get; } = random.NextInt64();
        public string Name { get; set; }
        public float HullLength { get; set; }
        public float OverallLength { get; set; }
        public float HullWidth { get; set; }
        public float OverallWidth { get; set; }
        public float Draft { get; set; }
        public float AirDraft { get; set; }
        public float Weight { get; set; }
        //public Polar? Polar = new Polar();

        public List<Polar> PolarFileList = new ();

        private static System.Random random = new System.Random(DateTime.Now.Millisecond);

        public BoatType()
        {
            Name = Locales.NewBoatType;
        }


        public bool Equals(BoatType? other)
        {
            if (other == null)
                return false;
            return ID.Equals(other.ID);
        }

        public int CompareTo(BoatType? other)
        {
            if (other == null)
            {
                logger.log(LoggingLevel.WARN, "BoatType.CompareTo", $"Comparaison between {Name}-{ID} and a null object");
                return 1;
            }
            
            return Name.CompareTo(other.Name);
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
 
    }
}