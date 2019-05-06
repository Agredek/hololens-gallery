using System;
using Constants;
using Retrofit;
using UniRx;

namespace Service
{
    public class FlickrClient
    {
        private readonly IFlickrService service;
        private readonly IFlickrCallback callback;

        public FlickrClient(IFlickrCallback callback)
        {
            this.callback = callback;
            var adapter = new RetrofitAdapter.Builder()
                .SetEndpoint(HttpConstants.Endpoint)
                .EnableLog(true)
                .SetErrorHandler(new DefaultErrorHandler())
                .Build();
            service = adapter.Create<IFlickrService>();
        }

        public void GetRecentPhotos(int perPage, int pageNumber)
        {
            service.GetRecent(HttpConstants.Recent, perPage, pageNumber, HttpConstants.QueryOptions)
                .SubscribeOn(Scheduler.ThreadPool)
                .ObserveOn(Scheduler.MainThread)
                .Subscribe(
                    data => callback.OnRecentSuccess(data),
                    error => callback.OnFailure(error)
                );
        }

        public void GetPhotoInfo(string photoId)
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