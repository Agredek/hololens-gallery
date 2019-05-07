using System.Collections.Generic;
using Newtonsoft.Json;

namespace Service.Model
{
    public class FlickrPhotoUrls
    {
        [JsonProperty(PropertyName = "url")]
        public IEnumerable<FlickrPhotoUrl> PhotoUrl { get; set; }

        public override string ToString()
        {
            return $"{string.Join(" ,", PhotoUrl)}";
        }
    }
}