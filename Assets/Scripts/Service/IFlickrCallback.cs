using System;
using Service.Response;

namespace Service
{
    internal interface IFlickrCallback
    {
        /// <summary>
        /// Called when recent photos are downloaded successfully.
        /// </summary>
        /// <param name="response">Response containing collection of recent photos.</param>
        void OnRecentSuccess(RecentPhotosResponse response);
        /// <summary>
        /// Called when details about one photo are downloaded successfully.
        /// </summary>
        /// <param name="response">Response containing detailed information about one photo.</param>
        void OnInfoSuccess(PhotoInfoResponse response);
        /// <summary>
        /// Called when request failed.
        /// </summary>
        /// <param name="e">Exception thrown.</param>
        void OnFailure(Exception e);
    }
}