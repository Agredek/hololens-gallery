using System;
using System.Collections.Generic;
using Constants;
using Service;
using Service.Model;
using Service.Response;
using UnityEngine;

internal class GalleryDownloader : MonoBehaviour, IFlickrCallback
{
    [SerializeField] [Range(1, 100)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;
    
    public delegate void DownloadFinished(Dictionary<string, PhotoViewModel> photos);

    public static event DownloadFinished OnDownloadFinished;

    private FlickrClient client;
    private Dictionary<string, PhotoViewModel> photos;

    private void Awake()
    {
        photos = new Dictionary<string, PhotoViewModel>();
        client = new FlickrClient(this);
    }

    public void OnRecentSuccess(RecentPhotosResponse response)
    {
        var photoList = response.RecentPhotos.PhotoList;
        foreach (var photo in photoList)
            photos.Add(photo.Id, new PhotoViewModel(photo));
        foreach (var photoViewModel in photos) 
            GetPhotoInfo(photoViewModel.Key);
    }

    public void OnInfoSuccess(PhotoInfoResponse response)
    {
        if (!photos.TryGetValue(response.PhotoInfo.Id, out var photoViewModel))
        {
            Debug.LogError($"Couldn't find photo of ID {response.PhotoInfo.Id}");
            return;
        }

        photoViewModel.OriginalFormat = response.PhotoInfo.OriginalFormat;
        var urls = response.PhotoInfo.Urls.PhotoUrl;
        foreach (var url in urls) 
            photoViewModel.Urls.Add(url.Url);
        
        if (photos.Count >= perPage)
            OnDownloadFinished?.Invoke(photos);
    }

    public void OnFailure(Exception e)
    {
        Debug.LogError(e);
    }
    
    public void GetRecentPhotos(int pageNumber)
    {
        client.GetRecentPhotos(perPage, pageNumber);
    }
    
    private void GetPhotoInfo(string photoId)
    {
        client.GetPhotoInfo(photoId);
    }
}