using System.Collections.Generic;
using Newtonsoft.Json;

namespace Service.Model
{
    public class PhotoUrls
    {
        [JsonProperty(PropertyName = "url")]
        public List<PhotoUrl> PhotoUrl { get; set; }

        public override string ToString()
        {
            return $"{string.Join(" ,", PhotoUrl)}";
        }
    }
}