using System.Collections.Generic;
using Service.Model;
using UnityEngine;

internal class Gallery : MonoBehaviour
{
    [SerializeField] private GalleryDownloader downloader;

    private void Start()
    {
        downloader.GetRecentPhotos(0);
    }

    private void OnEnable()
    {
        GalleryDownloader.OnDownloadFinished += OnDownloadFinished;
    }

    private void OnDisable()
    {
        GalleryDownloader.OnDownloadFinished -= OnDownloadFinished;
    }

    private void OnDownloadFinished(Dictionary<string, PhotoViewModel> photos)
    {
        Debug.Log($"Successfully downloaded {photos.Count} photos!");
        foreach (var photoViewModel in photos.Values) 
            Debug.Log(photoViewModel.SourceUrl());
    }
}