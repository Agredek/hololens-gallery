using Newtonsoft.Json;

namespace Service.Model
{
    public class RecentPhoto : BasePhoto
    {
        [JsonProperty(PropertyName = "owner")] public string Owner { get; set; }

        [JsonProperty(PropertyName = "title")] public string Title { get; set; }

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