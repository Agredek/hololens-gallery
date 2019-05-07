using System;
using System.Collections.Generic;
using Constants;
using Service;
using Service.Response;
using UnityEngine;

public class GalleryDownloader : MonoBehaviour, IFlickrCallback
{
    [SerializeField] [Range(1, 100)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;

    private FlickrClient client;
    public List<string> Urls { get; private set; }

    private void Start()
    {
        Urls = new List<string>();
        client = new FlickrClient(this);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Debug.Log(Urls.Count);
    }

    public void GetRecentPhotos(int pageNum)
    {
        client.GetRecentPhotos(perPage, pageNum);
    }

    public void GetPhotoInfo(string photoId)
    {
        client.GetPhotoInfo(photoId);
    }

    public void OnRecentSuccess(RecentPhotosResponse response)
    {
        var photos = response.RecentPhotos.PhotoList;
        foreach (var photo in photos)
            client.GetPhotoInfo(photo.Id);
    }

    public void OnInfoSuccess(PhotoInfoResponse response)
    {
        foreach (var photoUrl in response.PhotoInfo.Urls.PhotoUrl)
            Urls.Add(photoUrl.Url);
    }

    public void OnFailure(Exception e)
    {
        Debug.LogError(e);
    }
}