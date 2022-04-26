namespace RaceManager.Reading
{
    public class Polar : IEquatable<Polar>, IComparable<Polar>
    {
        private static RMLogger logger = new(LoggingLevel.INFO, "Polar");

        public string Name { get; set; }
        public string File { get; set; }

        public Int64 ID { get; } = BoatType.RandomInt64.NextInt64();

        public bool Equals(Polar? other)
        {
            if (other == null)
            {
                logger.log(LoggingLevel.WARN, "Equals", $"Comparaison between {Name}-{ID} and a null object");
                return false;
            }
            return ID.Equals(other.ID);
        }

        public int CompareTo(Polar? other)
        {
            if (other == null)
            {
                logger.log(LoggingLevel.WARN, "CompareTo", $"Comparaison between {Name}-{ID} and a null object");
                return 1;
            }

            return Name.CompareTo(other.Name);
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public string ToString()
        {
            return $"{Name}:{ID}";
        }
    }
}
