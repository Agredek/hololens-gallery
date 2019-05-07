using Newtonsoft.Json;
using Service.Model;

namespace Service.Response
{
    public class PhotoInfoResponse
    {
        [JsonProperty(PropertyName = "photo")] public FlickrPhotoInfo FlickrPhotoInfo { get; set; }

        public override string ToString()
        {
            return $"Id: {FlickrPhotoInfo.Id}, Farm: {FlickrPhotoInfo.Farm}, Secret: {FlickrPhotoInfo.Secret}, Media: {FlickrPhotoInfo.Media}, Urls: {FlickrPhotoInfo.Urls}";
        }
    }
}