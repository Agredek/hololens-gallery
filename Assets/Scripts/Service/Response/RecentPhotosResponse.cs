using Newtonsoft.Json;
using Service.Model;

namespace Service.Response
{
    public class RecentPhotosResponse
    {
        [JsonProperty(PropertyName = "photos")]
        public RecentPhotos RecentPhotos { get; set; }

        public override string ToString()
        {
            return $"Pages: {RecentPhotos.Pages}, Per Page: {RecentPhotos.PerPage}, Total: {RecentPhotos.Total}," +
                   $"Page: {RecentPhotos.Page}, Photos: {string.Join(", ", RecentPhotos.PhotoList)}";
        }
    }
}