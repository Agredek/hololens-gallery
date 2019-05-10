using System;
using System.Collections.Generic;
using Constants;
using TMPro;
using UnityEngine;

internal class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject contentContainer;

    [SerializeField] private TextMeshPro exceptionText;

    [SerializeField] [Range(1, 10)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;

    [SerializeField] private Photo photoPrefab;

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

    private void OnEnable()
    {
        GalleryDownloader.OnDownloadStarted += OnDownloadStarted;
        GalleryDownloader.OnDownloadFinished += OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed += OnDownloadFailed;
    }

    private void Start()
    {
        Initialize();
        NextPage();
    }

    private void Initialize()
    {
        var globalPerPage = (int) Global.Instance.perPage;
        if (globalPerPage == 0)
            Debug.LogError("Global per page value is 0! Probably didn't pass Awake yet!");
        else
            perPage = globalPerPage;
        
        downloader = new GalleryDownloader(perPage);
        photoObjects = new List<Photo>();

        for (var i = 0; i < perPage; ++i)
        {
            var photoInstance = Instantiate(photoPrefab, contentContainer.transform);
            photoObjects.Add(photoInstance);
        }
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