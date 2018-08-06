using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private Button selectButton;
    [SerializeField] private Button captureButton;
    [SerializeField] private Button markerlessStartButton;
    private CaptureViewController captureViewController;

    private void Awake()
    {
        captureViewController = GetComponent<CaptureViewController>();
    }

    private void Start()
    {
        captureButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("capture");
                captureViewController.CaptureTapped();
            });
    }
}
