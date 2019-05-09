using Constants;
using Retrofit;
using UniRx;

namespace Service
{
    internal class FlickrClient
    {
        private readonly IFlickrCallback callback;
        private readonly IFlickrService service;

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
                    data => callback.OnSuccess(data),
                    error => callback.OnFailure(error)
                );
        }
    }
}