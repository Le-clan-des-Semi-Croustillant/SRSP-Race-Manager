using System.Text.RegularExpressions;

namespace RaceManager.Reading
{
    public class BoatTypeField<T> : AField
    {
        // <summary>
        // The boat type field.
        // </summary>
        public T Value = default(T);
        RMLogger logger = new RMLogger(LoggingLevel.DEBUG, "BoatTypeField");

        public override bool StoreValue()
        {
            isValid = false;
            try
            {
                Value = (T)Convert.ChangeType(FieldContent, typeof(T));
                if ((typeof(T) == typeof(string)) && !Regex.IsMatch(Value.ToString(), @"^[a-zA-Z0-9_-]+$"))
                {
                    logger.log(LoggingLevel.DEBUG, "StoreValue()", $"Value stored: {Value} {(typeof(T) != typeof(string))} {Regex.IsMatch(Value.ToString(), @"^[a-zA-Z0-9_-]+$")}");
                    throw new Exception("{Value} does not match the regex ^[a-zA-Z0-9_-]+$ (alphanum)");
                }

                isValid = true;
                Style = "";
                logger.log(LoggingLevel.DEBUG, "StoreValue()", $"{FieldContent} is valid.");

            }
            catch (Exception e)
            {
                //Value = default(T);
                Style = "color: red;border-color: red";
                logger.log(LoggingLevel.ERROR, "StoreValue()", $"Error when trying to cast {FieldContent} with \"{e.Message}\"");
            }
            return isValid;
        }
    }
}
