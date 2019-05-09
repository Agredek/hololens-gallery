using Service.Model;

namespace Utils
{
    public static class FlickrUtil
    {
        public static string GetPhotoUrl(RecentFlickrPhoto photo)
        {
            return $"https://farm{photo.Farm}.staticflickr.com/{photo.Server}/{photo.Id}_{photo.Secret}.jpg";
        }
    }
}