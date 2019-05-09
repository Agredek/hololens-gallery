using Newtonsoft.Json;

namespace Service.Model
{
    public abstract class BaseFlickrPhoto
    {
        protected BaseFlickrPhoto(BaseFlickrPhoto other)
        {
            Id = other.Id;
            Secret = other.Secret;
            Server = other.Server;
            Farm = other.Farm;
        }

        protected BaseFlickrPhoto()
        {
        }

        protected BaseFlickrPhoto(string id, string secret, string server, int farm)
        {
            Id = id;
            Secret = secret;
            Server = server;
            Farm = farm;
        }

        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; }

        [JsonProperty(PropertyName = "farm")] public int Farm { get; set; }
    }
}