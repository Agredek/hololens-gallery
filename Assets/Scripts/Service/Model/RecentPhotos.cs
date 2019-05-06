using System.Collections.Generic;
using Newtonsoft.Json;

namespace Service.Model
{
    public class RecentPhotos
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        
        [JsonProperty(PropertyName = "pages")]
        public int Pages { get; set; }
        
        [JsonProperty(PropertyName = "perpage")]
        public int PerPage { get; set; }
        
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        
        [JsonProperty(PropertyName = "photo")]
        public List<RecentPhoto> PhotoList { get; set; }
    }
}