using Newtonsoft.Json;
using Service.Model;

namespace Service.Response
{
    public class PhotoInfoResponse
    {
        [JsonProperty(PropertyName = "photo")] public PhotoInfo PhotoInfo { get; set; }

        public override string ToString()
        {
            return $"Id: {PhotoInfo.Id}, Farm: {PhotoInfo.Farm}, Secret: {PhotoInfo.Secret}, Media: {PhotoInfo.Media}, Urls: {PhotoInfo.Urls}";
        }
    }
}