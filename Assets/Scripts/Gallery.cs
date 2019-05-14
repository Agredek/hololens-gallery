using System;
using System.Collections.Generic;
using Constants;
using TMPro;
using UnityEngine;

internal class Gallery : MonoBehaviour
{
    [SerializeField] private TextMeshPro exceptionText;

    [SerializeField] [Range(1, 10)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;

    [SerializeField] private List<Photo> photoObjects;

    private GalleryDownloader downloader;

    private int page = -1;

    public void NextPage()
    {
        downloader.GetRecentPhotos(page++);
    }

    public void PreviousPage()
    {
        if (page <= 0)
            return;
        downloader.GetRecentPhotos(page--);
    }

    public void UpdateWindow(int picturesAmount)
    {
        if (perPage == picturesAmount)
            return;
        perPage = picturesAmount;
        downloader.PerPage = perPage;
        NextPage();
    }

    private void OnEnable()
    {
        GalleryDownloader.OnDownloadStarted += OnDownloadStarted;
        GalleryDownloader.OnDownloadFinished += OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed += OnDownloadFailed;
    }

    private void Start()
    {
        downloader = new GalleryDownloader {PerPage = perPage};
        NextPage();
    }

    private void OnDisable()
    {
        GalleryDownloader.OnDownloadStarted -= OnDownloadStarted;
        GalleryDownloader.OnDownloadFinished -= OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed -= OnDownloadFailed;
    }

    private void OnDownloadStarted()
    {
        foreach (var photoObject in photoObjects)
            photoObject.Disable();
    }

    private void OnDownloadFinished(List<Texture2D> photos)
    {
        Debug.Log($"Successfully downloaded {photos.Count} photos!");
        for (var i = 0; i < photos.Count; ++i) 
            photoObjects[i].SetPhoto(photos[i]);
    }

    private void OnDownloadFailed(Exception e)
    {
        Debug.LogError(e);
        exceptionText.text = e.Message;
    }
}