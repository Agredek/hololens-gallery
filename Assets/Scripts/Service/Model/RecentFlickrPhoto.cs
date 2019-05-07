using Newtonsoft.Json;

namespace Service.Model
{
    public class RecentFlickrPhoto : BaseFlickrPhoto
    {
        [JsonProperty(PropertyName = "owner")] internal string Owner { get; set; }

        [JsonProperty(PropertyName = "title")] internal string Title { get; set; }

        [JsonProperty(PropertyName = "ispublic")]
        public bool IsPublic { get; set; }

        [JsonProperty(PropertyName = "isfriend")]
        public bool IsFriend { get; set; }

        [JsonProperty(PropertyName = "isfamily")]
        public bool IsFamily { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}, Owner: {Owner}, Title: {Title}, IsPublic: {IsPublic}, IsFriend: {IsFriend}, IsFamily: {IsFamily}";
        }
    }
}