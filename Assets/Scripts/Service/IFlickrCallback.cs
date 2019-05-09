using System;
using Service.Response;

namespace Service
{
    internal interface IFlickrCallback
    {
        /// <summary>
        ///     Called when recent photos are downloaded successfully.
        /// </summary>
        /// <param name="response">Response containing collection of recent photos.</param>
        void OnSuccess(RecentPhotosResponse response);

        /// <summary>
        ///     Called when request failed.
        /// </summary>
        /// <param name="e">Exception thrown.</param>
        void OnFailure(Exception e);
    }
}