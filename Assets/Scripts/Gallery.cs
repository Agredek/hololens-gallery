using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GalleryDownloader))]
internal class Gallery : MonoBehaviour
{
    [SerializeField] private GalleryDownloader downloader;
    [SerializeField] private GameObject contentContainer;
    [SerializeField] private Photo photoPrefab;

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

    private void OnDownloadFinished(List<Texture2D> photos)
    {
        Debug.Log($"Successfully downloaded {photos.Count} photos!");
        foreach (var texture in photos)
        {
            var photoInstance = Instantiate(photoPrefab, contentContainer.transform);
            photoInstance.SetPhoto(texture);
        }
    }
}