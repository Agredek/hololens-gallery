using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using Service;
using Service.Model;
using Service.Response;
using UnityEngine;
using UnityEngine.Networking;

internal class GalleryDownloader : MonoBehaviour, IFlickrCallback
{
    [SerializeField] [Range(1, 100)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;

    public delegate void DownloadFinished(List<Texture2D> photos);

    public static event DownloadFinished OnDownloadFinished;

    public delegate void DownloadFailed(Exception e);

    public static event DownloadFailed OnDownloadFailed;

    private bool hasInvoked;

    private FlickrClient client;
    private Dictionary<string, FlickrPhotoViewModel> flickrPhotoViewModels;
    private List<Texture2D> photos;

    private void Awake()
    {
        flickrPhotoViewModels = new Dictionary<string, FlickrPhotoViewModel>();
        photos = new List<Texture2D>();
        client = new FlickrClient(this);
    }

    private void Update()
    {
        if (photos.Count < perPage || hasInvoked)
            return;
        hasInvoked = true;
        OnDownloadFinished?.Invoke(photos);
    }

    public void OnRecentSuccess(RecentPhotosResponse response)
    {
        var photoList = response.RecentFlickrPhotos.PhotoList;
        foreach (var photo in photoList)
            flickrPhotoViewModels.Add(photo.Id, new FlickrPhotoViewModel(photo));
        foreach (var photoViewModel in flickrPhotoViewModels)
            GetPhotoInfo(photoViewModel.Key);
    }

    public void OnInfoSuccess(PhotoInfoResponse response)
    {
        var photoInfo = response.FlickrPhotoInfo;
        if (!flickrPhotoViewModels.TryGetValue(photoInfo.Id, out var photoViewModel))
        {
            Debug.LogError($"Couldn't find photo of ID {photoInfo.Id}");
            return;
        }

        if (photoInfo.OriginalFormat != null)
            photoViewModel.OriginalFormat = photoInfo.OriginalFormat;

        var urls = photoInfo.Urls.PhotoUrl;
        foreach (var url in urls)
            photoViewModel.Urls.Add(url.Url);

        if (flickrPhotoViewModels.Count < perPage)
            return;
        foreach (var photo in flickrPhotoViewModels.Values)
            StartCoroutine(DownloadPhoto(photo.SourceUrl()));
    }

    public void OnFailure(Exception e)
    {
        OnDownloadFailed?.Invoke(e);
    }

    public void GetRecentPhotos(int pageNumber)
    {
        client.GetRecentPhotos(perPage, pageNumber);
    }

    private void GetPhotoInfo(string photoId)
    {
        client.GetPhotoInfo(photoId);
    }

    private IEnumerator DownloadPhoto(string url)
    {
        var www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
            OnFailure(new Exception($"An exception occurred while downloading photo from {url}. {www.error}"));
        else
        {
            var photo = ((DownloadHandlerTexture) www.downloadHandler).texture;
            photos.Add(photo);
        }
    }
}