using Newtonsoft.Json;

namespace EAFramework.Config
{
    public static class ReadConfig
    {
        public static TestSettings ReadJsonFile()
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            var jsonbody = File.ReadAllText(jsonFilePath);
            var testSettings = JsonConvert.DeserializeObject<TestSettings>(jsonbody);
            return testSettings;
        }

    }
}
