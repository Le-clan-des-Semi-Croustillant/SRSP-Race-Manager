namespace RaceManager.Reading
{
    /// <summary>
    /// Field Abstract class
    /// </summary>
    public abstract class AField
    {
        public string Label;
        public bool isValid = true;
        public abstract bool StoreValue();
        public string FieldContent;
        public string Style = "";
     }
}
