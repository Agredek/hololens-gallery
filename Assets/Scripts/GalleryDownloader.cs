using System;
using System.Collections.Generic;
using Service;
using Service.Response;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using Utils;

internal class GalleryDownloader : IFlickrCallback
{
    public delegate void DownloadFailed(Exception e);

    public delegate void DownloadFinished(List<Texture2D> photos);

    private readonly FlickrClient client;

    private readonly int perPage;
    private readonly List<Texture2D> photos;

    private int pages;

    public GalleryDownloader(int perPage)
    {
        this.perPage = perPage;
        photos = new List<Texture2D>();
        client = new FlickrClient(this);
    }

    public void OnSuccess(RecentPhotosResponse response)
    {
        pages = response.RecentFlickrPhotos.Pages;
        
        var photoList = response.RecentFlickrPhotos.PhotoList;
        foreach (var photo in photoList)
            DownloadPhoto(FlickrUtil.GetPhotoUrl(photo));
    }

    public void OnFailure(Exception e)
    {
        OnDownloadFailed?.Invoke(e);
    }

    public static event DownloadFinished OnDownloadFinished;

    public static event DownloadFailed OnDownloadFailed;

    /// <summary>
    /// Download photos for a page.
    /// </summary>
    /// <param name="pageNumber"></param>
    public bool GetRecentPhotos(int pageNumber)
    {
        if (pageNumber > pages)
            return false;
        client.GetRecentPhotos(perPage, pageNumber);
        return true;
    }

    private void DownloadPhoto(string url)
    {
        var www = UnityWebRequestTexture.GetTexture(url);
        www.SendWebRequest()
            .AsAsyncOperationObservable()
            .Subscribe(
                success =>
                {
                    var photo = ((DownloadHandlerTexture) www.downloadHandler).texture;
                    photos.Add(photo);
                    if (photos.Count >= perPage)
                        OnDownloadFinished?.Invoke(photos);
                },
                failure =>
                {
                    OnFailure(new Exception($"An exception occurred while downloading photo from {url}.", failure));
                }
            );
    }
}