namespace RaceManager.Reading
{
    /// <summary>
    /// Class of boat polar information
    /// </summary>
    public class Polar : IEquatable<Polar>, IComparable<Polar>
    {
        private static RMLogger logger = new(LoggingLevel.INFO, "Polar");

        public string Name { get; set; }
        public string File { get; set; }

        public Int64 ID { get; set; } = Math.Abs(BoatType.RandomInt64.NextInt64());

        /// <summary>
        /// Redefinition of the Equals method.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Polar? other)
        {
            if (other == null)
            {
                logger.log(LoggingLevel.WARN, "Equals", $"Comparaison between {Name}-{ID} and a null object");
                return false;
            }
            return ID.Equals(other.ID);
        }

        /// <summary>
        /// Redefinition of the CompareTo method.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Polar? other)
        {
            if (other == null)
            {
                logger.log(LoggingLevel.WARN, "CompareTo", $"Comparaison between {Name}-{ID} and a null object");
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Convert to tring
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return $"{Name}:{ID}:{File}";
        }
    }
}
