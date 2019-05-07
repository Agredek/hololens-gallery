using Newtonsoft.Json;

namespace Service.Model
{
    public class PhotoViewModel : BasePhoto
    {
        public PhotoViewModel(string id, string secret, string server, int farm, string originalFormat) : base(id,
            secret, server, farm)
        {
            OriginalFormat = originalFormat;
        }

        [JsonProperty(PropertyName = "originalformat")]
        public string OriginalFormat { get; set; }

        public string SourceUrl()
        {
            return $"https://farm{Farm}.staticflickr.com/{Server}/{Id}_{Secret}.{OriginalFormat}";
        }
    }
}