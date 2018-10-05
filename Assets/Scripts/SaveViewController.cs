using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Kudan.AR.Samples;

public class SaveViewController : MonoBehaviour
{
    [SerializeField] private CanvasGroup saveViewGroup;

    public void SaveTapped()
    {
        StartCoroutine(SaveTappedCoroutine());
    }

    private IEnumerator SaveTappedCoroutine()
    {
        saveViewGroup.interactable = false;

        yield return null;

        string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = timeStamp + ".png";
        NativeGallery.SaveImageToGallery(CaptureViewController.PhotoTexture, "FireworkAR", fileName);

        yield return new WaitForEndOfFrame();

        ViewChanger.Instance.ChangeView();
        saveViewGroup.interactable = true;
    }

    public void ShareTapped()
    {
        StartCoroutine(ShareTappedCoroutine());
    }

    private IEnumerator ShareTappedCoroutine()
    {
        string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = timeStamp + ".png";
        string imagePath = Application.persistentDataPath + "/" + fileName;
        ScreenCapture.CaptureScreenshot(fileName);
        saveViewGroup.interactable = false;

        while (true)
        {
            if (File.Exists(imagePath)) break;
            yield return null;
        }

        var text = "#FireworkAR";
        var url = "";
        SocialConnector.SocialConnector.Share(text, url, imagePath);
        saveViewGroup.interactable = true;
    }

    public void BackTapped()
    {
        ViewChanger.Instance.ChangeView();
    }
}
