 
namespace RaceManager.Reading
{
    public class BoatTypeField<T> : AField
    {
        // <summary>
        // The boat type field.
        // </summary>
        public T Value = default(T);
        RMLogger logger = new RMLogger(LoggingLevel.INFO, "BoatTypeField");

        public override bool StoreValue()
        {
            try
            {
                Value = (T)Convert.ChangeType(FieldContent, typeof(T));
                isValid = true;
                Style = "";
                logger.log(LoggingLevel.DEBUG, "StoreValue()", $"{FieldContent} is valid.");

            }
            catch (Exception e)
            {
                //Value = default(T);
                isValid = false;
                Style = "color: red;border-color: red";
                logger.log(LoggingLevel.ERROR, "StoreValue()", $"Error when trying to cast {FieldContent} with \"{e.Message}\"");
            }
            return isValid;
        }
    }
}
