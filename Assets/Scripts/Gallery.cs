using System;
using Constants;
using Service;
using Service.Response;
using UnityEngine;

public class Gallery : MonoBehaviour, IFlickrCallback
{
    [SerializeField] [Range(1, 100)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;
    
    private FlickrClient client;
    
    private void Start()
    {
        client = new FlickrClient(this);
        client.GetRecentPhotos(perPage, 0);
    }

    public void OnRecentSuccess(RecentPhotosResponse response)
    {
        Debug.Log(response);
        var photos = response.RecentPhotos.PhotoList;
        client.GetPhotoInfo(photos[0].Id);
    }

    public void OnInfoSuccess(string response)
    {
        Debug.Log(response);
    }

    public void OnFailure(Exception e)
    {
        Debug.LogError(e);
    }
}