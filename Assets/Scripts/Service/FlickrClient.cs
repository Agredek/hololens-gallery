using Constants;
using Retrofit;
using UniRx;

namespace Service
{
    internal class FlickrClient
    {
        private readonly IFlickrService service;
        private readonly IFlickrCallback callback;

        internal FlickrClient(IFlickrCallback callback)
        {
            this.callback = callback;
            var adapter = new RetrofitAdapter.Builder()
                .SetEndpoint(HttpConstants.Endpoint)
                .SetErrorHandler(new DefaultErrorHandler())
                .Build();
            service = adapter.Create<IFlickrService>();
        }

        /// <summary>
        ///     Download collection of recently uploaded photos.
        /// </summary>
        /// <param name="perPage">How many photos should one page contain.</param>
        /// <param name="pageNumber">Page number.</param>
        internal void GetRecentPhotos(int perPage, int pageNumber)
        {
            service.GetRecent(HttpConstants.Recent, perPage, pageNumber, HttpConstants.QueryOptions)
                .SubscribeOn(Scheduler.ThreadPool)
                .ObserveOn(Scheduler.MainThread)
                .Subscribe(
                    data => callback.OnRecentSuccess(data),
                    error => callback.OnFailure(error)
                );
        }

        /// <summary>
        ///     Download detailed info about one picture.
        /// </summary>
        /// <param name="photoId">ID of photo to download.</param>
        internal void GetPhotoInfo(string photoId)
        {
            service.GetInfo(HttpConstants.PhotoInfo, photoId, HttpConstants.QueryOptions)
                .SubscribeOn(Scheduler.ThreadPool)
                .ObserveOn(Scheduler.MainThread)
                .Subscribe(
                    data => callback.OnInfoSuccess(data),
                    error => callback.OnFailure(error)
                );
        }
    }
}