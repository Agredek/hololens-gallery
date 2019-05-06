using System;
using Service.Response;

namespace Service
{
    public interface IFlickrCallback
    {
        void OnRecentSuccess(RecentPhotosResponse response);
        void OnInfoSuccess(string response);
        void OnFailure(Exception e);
    }
}