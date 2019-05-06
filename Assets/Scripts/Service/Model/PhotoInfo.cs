using Newtonsoft.Json;

namespace Service.Model
{
    public class PhotoInfo : BasePhoto
    {
        [JsonProperty(PropertyName = "dateuploaded")]
        public long DateUploaded { get; set; }

        [JsonProperty(PropertyName = "isfavorite")]
        public bool IsFavorite { get; set; }

        [JsonProperty(PropertyName = "originalformat")]
        public string OriginalFormat { get; set; }

        [JsonProperty(PropertyName = "urls")] public PhotoUrls Urls { get; set; }

        [JsonProperty(PropertyName = "media")] public string Media { get; set; }
    }
}