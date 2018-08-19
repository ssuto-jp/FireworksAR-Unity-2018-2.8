using System;
using System.Collections;
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
        StartCoroutine("SaveTappedCoroutine");
    }

    private IEnumerator SaveTappedCoroutine()
    {
        string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = timeStamp + ".png";
        NativeGallery.SaveImageToGallery(CaptureViewController.PhotoTexture, "FireworkAR", fileName);

        yield return new WaitForEndOfFrame();

        BackToScene();
    }

    public void ShareTapped()
    {
        var text = "#FireworkAR";
        var url = "";
        SocialConnector.SocialConnector.Share(text, url, null);
    }

    public void BackTapped()
    {
        BackToScene();
    }

    private void BackToScene()
    {
        SceneManager.LoadScene("CaptureViewScene");
    }
}
