using Newtonsoft.Json;

namespace Service.Model
{
    public abstract class BasePhoto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }
        
        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; }
        
        [JsonProperty(PropertyName = "farm")]
        public int Farm { get; set; }
    }
}