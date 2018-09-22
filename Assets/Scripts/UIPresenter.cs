﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using Kudan.AR.Samples;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private Button selectButton;
    [SerializeField] private Button captureButton;
    [SerializeField] private Button markerlessStartButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button fireworkButton;

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
                    captureViewController.SelectTapped();
                });

            closeButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    captureViewController.CloseSelectPanel();
                });

            captureButton.OnClickAsObservable()
                 .Subscribe(_ =>
                 {
                     captureViewController.CaptureTapped();
                 });

            markerlessStartButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    captureViewController.MarkerlessStartTapped();
                });

            fireworkButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    captureViewController.FireworkTapped();
                });
        }

        if (SceneManager.GetActiveScene().name == "SaveViewScene")
        {
            backButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    saveViewController.BackTapped();
                });

            saveButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    saveViewController.SaveTapped();
                });

            shareButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    saveViewController.ShareTapped();
                });
        }
    }
}
