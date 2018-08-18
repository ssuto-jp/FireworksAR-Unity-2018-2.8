using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveViewController : MonoBehaviour
{
    [SerializeField] private RawImage photoImage;

    private void Start()
    {
        photoImage.texture = CaptureViewController.PhotoTexture;
    }

    public void SaveTapped()
    {
        string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = timeStamp + ".png";
        NativeGallery.SaveImageToGallery(CaptureViewController.PhotoTexture, "FireworkAR", fileName);
    }

    public void ShareTapped()
    {
        var text = "#FireworkAR";
        var url = "";
        SocialConnector.SocialConnector.Share(text, url, null);
    }

    public void BackTapped()
    {
        //
    }

    private void BackToScene()
    {
        SceneManager.LoadScene("CaptureViewScene");
    }
}
