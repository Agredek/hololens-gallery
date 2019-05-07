using Newtonsoft.Json;

namespace Service.Model
{
    public class FlickrPhotoUrl
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        
        [JsonProperty(PropertyName = "_content")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}, Url: {Url}";
        }
    }
}