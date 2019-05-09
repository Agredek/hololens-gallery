using System;
using System.Collections.Generic;
using Constants;
using TMPro;
using UnityEngine;

internal class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject contentContainer;

    [SerializeField] private TextMeshPro exceptionText;

    [SerializeField] [Range(1, 100)] [Tooltip(Tooltips.PerPage)]
    private int perPage = 10;

    [SerializeField] private Photo photoPrefab;
    
    private GalleryDownloader downloader;

    private void OnEnable()
    {
        GalleryDownloader.OnDownloadFinished += OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed += OnDownloadFailed;
    }

    private void Awake()
    {
        downloader = new GalleryDownloader(perPage);
    }

    private void Start()
    {
        downloader.GetRecentPhotos(0);
    }

    private void OnDisable()
    {
        GalleryDownloader.OnDownloadFinished -= OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed -= OnDownloadFailed;
    }

    private void OnDownloadFinished(List<Texture2D> photos)
    {
        Debug.Log($"Successfully downloaded {photos.Count} photos!");
        foreach (var texture in photos)
        {
            var photoInstance = Instantiate(photoPrefab, contentContainer.transform);
            photoInstance.SetPhoto(texture);
        }
    }

    private void OnDownloadFailed(Exception e)
    {
        Debug.LogError(e);
        exceptionText.text = e.Message;
    }
}