 
namespace RaceManager.Reading
{
    public class BoatTypeField<T> : AField
    {
        // <summary>
        // The boat type field.
        // </summary>
        public T Value;

        public override bool StoreValue()
        {
            try
            {
                Value = (T)Convert.ChangeType(FieldContent, typeof(T));
                isValid = true;
                Style = "";
                Logger.log(LoggingLevel.DEBUG, "BoatTypes.razor", $"{FieldContent} is valid.");

            }
            catch (Exception e)
            {
                //Value = default(T);
                isValid = false;
                Style = "color: red;border-color: red";
                Logger.log(LoggingLevel.ERROR, "BoatTypes.razor", $"Error when trying to cast {FieldContent} with \"{e.Message}\"");
            }
            return isValid;
        }
    }
}
