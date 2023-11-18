namespace Game_Forest_Test_Task.source.tools
{
    public class Resources
    {
        private const string resourcesFolder = "resources/";
        private const string imageFolder = "image/";
        private const string jsonFolder = "json/";
        private const string jsonExtention = ".json";
        private const string pngExtention = ".png";
        public static T? LoadFromJson<T>(string filename)
        {
            var json = File.ReadAllText(PathToJson(filename));
            return JsonSerializer.Deserialize<T>(json);
        }

        public static void SaveToJson<T>(T data, string filename)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(PathToJson(filename), json);
        }

        public static Image LoadImage(string filename)
        {
            return Image.FromFile(PathToPng(filename));
        }

        private static string PathToJson(string filename) => resourcesFolder + jsonFolder + filename + jsonExtention;

        private static string PathToPng(string filename) => resourcesFolder + imageFolder + filename + pngExtention;
    }
}