namespace RaceManager.Reading
{
    public abstract class AField
    {
        // <summary>
        // Abstract field
        // </summary>
        public string Label;
        public bool isValid = true;
        public abstract bool StoreValue();
        public string FieldContent;
        public string Style = "";
     }
}
