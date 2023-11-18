namespace Game_Forest_Test_Task.source.tools
{
    public class JsonSerializer
    {
        public static string Serialize<T>(T data)
        {
            return System.Text.Json.JsonSerializer.Serialize(data);
        }

        public static T? Deserialize<T>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }
    }
}