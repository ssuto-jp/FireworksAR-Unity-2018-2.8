using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private Button selectButton;
    [SerializeField] private Button captureButton;
    [SerializeField] private Button markerlessStartButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private Button backButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button shareButton;

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
            selectButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("select");
                    captureViewController.SelectTapped();
                });

            closeButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("close");
                    captureViewController.CloseSelectPanel();
                });

            captureButton.OnClickAsObservable()
                 .Subscribe(_ =>
                 {
                     Debug.Log("capture");
                     captureViewController.CaptureTapped();
                 });
        }

        if (SceneManager.GetActiveScene().name == "SaveViewScene")
        {
            backButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("back");
                    saveViewController.BackTapped();
                });

            saveButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("save");
                    saveViewController.SaveTapped();
                });

            shareButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("share");
                    saveViewController.ShareTapped();
                });
        }
    }
}
