using UnityEngine;
using UnityEngine.UI;

public class SaveViewController : MonoBehaviour
{
    [SerializeField] private RawImage photoImage;

    private void Start()
    {
        photoImage.texture = CaptureViewController.PhotoTexture;
    }

}
