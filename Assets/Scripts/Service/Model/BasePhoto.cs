using Newtonsoft.Json;

namespace Service.Model
{
    public abstract class BasePhoto
    {
        protected BasePhoto(BasePhoto other)
        {
            Id = other.Id;
            Secret = other.Secret;
            Server = other.Server;
            Farm = other.Farm;
        }
        
        protected BasePhoto()
        {
        }

        protected BasePhoto(string id, string secret, string server, int farm)
        {
            Id = id;
            Secret = secret;
            Server = server;
            Farm = farm;
        }

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