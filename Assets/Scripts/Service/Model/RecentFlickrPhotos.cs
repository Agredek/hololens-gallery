using System.Collections.Generic;
using Newtonsoft.Json;

namespace Service.Model
{
    public class RecentFlickrPhotos
    {
        [JsonProperty(PropertyName = "page")] 
        public int PageNumber { get; set; }

        [JsonProperty(PropertyName = "pages")] 
        public int PageCount { get; set; }

        [JsonProperty(PropertyName = "perpage")]
        public int PerPage { get; set; }

        [JsonProperty(PropertyName = "total")] 
        public int Total { get; set; }

        [JsonProperty(PropertyName = "photo")] 
        public List<RecentFlickrPhoto> PhotoList { get; set; }
    }
}