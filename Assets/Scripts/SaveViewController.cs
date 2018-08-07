using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveViewController : MonoBehaviour
{
    [SerializeField] private RawImage photoImage;

    private void Start()
    {
        photoImage.texture = CaptureViewController.PhotoTexture;
    }

    public void SaveTapped()
    {
        string timeStamp = DateTime.Now.ToString("yyyyMMdd--HHmmss");
        string fileName = timeStamp + ".png";
        NativeGallery.SaveImageToGallery(CaptureViewController.PhotoTexture, "FireworkAR", fileName);
    }

}
