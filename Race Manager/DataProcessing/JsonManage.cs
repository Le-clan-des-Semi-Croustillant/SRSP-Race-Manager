using Race_Manager.DataProcessing;

namespace Race_Manager.DataProcessing
{
    public class JsonManage
    {

        public static void JsonType(string data)
        {
            dynamic informationJson = JsonParse.JsonDeserialize(data);
            Console.WriteLine(informationJson);
            try
            {

            }
            catch (Exception ex)
            {

            }

            switch (informationJson.TypeMessage)
            {
                case 0:

                case 1:

                case 2:

                case 3:

                default:
                    break;
            }
        }
    }
}
