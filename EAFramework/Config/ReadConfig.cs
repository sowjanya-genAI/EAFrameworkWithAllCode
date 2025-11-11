using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFramework.Config
{
    public static class ReadConfig
    {
        public static TestSettings ReadJsonFile()
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory,"appsettings.json");

            var jsonbody = File.ReadAllText(jsonFilePath);
            var productDetail = JsonConvert.DeserializeObject<TestSettings>(jsonbody);
            return productDetail;
        }
    }
}
