using Newtonsoft.Json;
using Service.Model;

namespace Service.Response
{
    public class RecentPhotosResponse
    {
        [JsonProperty(PropertyName = "photos")]
        public RecentFlickrPhotos RecentFlickrPhotos { get; set; }

        public override string ToString()
        {
            return
                $"Pages: {RecentFlickrPhotos.Pages}, Per Page: {RecentFlickrPhotos.PerPage}, Total: {RecentFlickrPhotos.Total}," +
                $"Page: {RecentFlickrPhotos.Page}, Photos: {string.Join(", ", RecentFlickrPhotos.PhotoList)}";
        }
    }
}