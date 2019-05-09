using System.Collections.Generic;

namespace Constants
{
    public static class HttpConstants
    {
        public const string Endpoint = "https://api.flickr.com/services/rest/";

        public const string Method = "method";
        public const string Recent = "flickr.photos.getRecent";
        public const string PhotoInfo = "flickr.photos.getInfo";

        public const string PerPage = "per_page";
        public const string Page = "page";
        public const string PhotoId = "photo_id";

        private const string ApiKeyKey = "api_key";
        private const string ApiKeyValue = "cdf387b2e20bb72c3de5eb72c658e13c";

        private const string Format = "format";
        private const string JsonFormat = "json";

        private const string NoJsonCallback = "nojsoncallback";

        public static readonly Dictionary<string, string> QueryOptions = new Dictionary<string, string>
        {
            {ApiKeyKey, ApiKeyValue},
            {Format, JsonFormat},
            {NoJsonCallback, "1"}
        };
    }
}