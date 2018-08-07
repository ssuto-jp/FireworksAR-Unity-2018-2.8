using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private Button selectButton;
    [SerializeField] private Button captureButton;
    [SerializeField] private Button markerlessStartButton;

    [SerializeField] private Button saveButton;

    private CaptureViewController captureViewController;
    private SaveViewController saveViewController;

    private void Awake()
    {
        captureViewController = GetComponent<CaptureViewController>();
        saveViewController = GetComponent<SaveViewController>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "CaptureViewScene")
        {
            captureButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("capture");
                captureViewController.CaptureTapped();
            });
        }

        if (SceneManager.GetActiveScene().name == "SaveViewScene")
        {
            saveButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            Debug.Log("save");
            saveViewController.SaveTapped();
        });
        }

    }
}
