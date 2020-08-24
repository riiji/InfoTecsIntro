using Newtonsoft.Json;

namespace InfoTecsIntro.Config
{
    public class JsonConfig<T> : IGetConfig<T>
    {
        private readonly string _jsonPath;

        public JsonConfig(string jsonPath)
        {
            _jsonPath = jsonPath;
        }

        public T GetConfig()
        {
            return JsonConvert.DeserializeObject<T>(_jsonPath);
        }
    }
}