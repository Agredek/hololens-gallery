using System;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] [Range(1f, 500f)] [Tooltip(Tooltips.RotationSpeed)]
    private float rotateSpeed = 200f;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        GalleryDownloader.OnDownloadFinished += OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed += OnDownloadFailed;
    }

    private void OnDisable()
    {
        GalleryDownloader.OnDownloadFinished -= OnDownloadFinished;
        GalleryDownloader.OnDownloadFailed -= OnDownloadFailed;
    }

    private void OnDownloadFinished(List<Texture2D> photos)
    {
        Disable();
    }

    private void OnDownloadFailed(Exception e)
    {
        Disable();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}