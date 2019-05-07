using System.Collections.Generic;
using Newtonsoft.Json;

namespace Service.Model
{
    internal class FlickrPhotoViewModel : BaseFlickrPhoto
    {
        internal FlickrPhotoViewModel(RecentFlickrPhoto flickrPhoto) : base(flickrPhoto)
        {
            Owner = flickrPhoto.Owner;
            Title = flickrPhoto.Title;
            Urls = new List<string>();
            OriginalFormat = "jpg";
        }

        [JsonProperty(PropertyName = "originalformat")]
        internal string OriginalFormat { get; set; }

        [JsonProperty(PropertyName = "owner")] internal string Owner { get; set; }

        [JsonProperty(PropertyName = "title")] internal string Title { get; set; }

        [JsonProperty(PropertyName = "urls")] internal List<string> Urls { get; set; }

        public string SourceUrl()
        {
            return $"https://farm{Farm}.staticflickr.com/{Server}/{Id}_{Secret}.{OriginalFormat}";
        }
    }
}