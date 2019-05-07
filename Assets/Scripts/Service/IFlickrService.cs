using System.Collections.Generic;
using Constants;
using Retrofit.Methods;
using Retrofit.Parameters;
using Service.Response;
using UniRx;

namespace Service
{
    public interface IFlickrService
    {
        [Get("")]
        IObservable<RecentPhotosResponse> GetRecent(
            [Query(HttpConstants.Method)] string method,
            [Query(HttpConstants.PerPage)] int perPage,
            [Query(HttpConstants.Page)] int page,
            [QueryMap] Dictionary<string, string> options);

        [Get("")]
        IObservable<PhotoInfoResponse> GetInfo(
            [Query(HttpConstants.Method)] string method,
            [Query(HttpConstants.PhotoId)] string photoId,
            [QueryMap] Dictionary<string, string> options);
    }
}