using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Kudan.AR.Samples
{
    public class CaptureViewController : MonoBehaviour
    {
        [SerializeField] private GameObject button;
        [SerializeField] private Button markerlessStartButton;
        [SerializeField] private GameObject selectPanel;
        [SerializeField] private KudanTracker _kudanTracker;
        [SerializeField] private TrackingMethodMarkerless _markerlessTracking;

        private static Texture2D _photoTexture;
        public static Texture2D PhotoTexture
        {
            get { return _photoTexture; }
        }

        public void CaptureTapped()
        {
            StartCoroutine("CaptureTappedCoroutine");
        }

        private IEnumerator CaptureTappedCoroutine()
        {
            button.SetActive(false);

            yield return new WaitForEndOfFrame();

            _photoTexture = new Texture2D(Screen.width, Screen.height);
            _photoTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            _photoTexture.Apply();

            yield return new WaitForEndOfFrame();

            NextToScene();
        }

        public void SelectTapped()
        {
            selectPanel.SetActive(true);
        }

        public void CloseSelectPanel()
        {
            selectPanel.SetActive(false);
        }

        public void FireworkTapped()
        {
            _kudanTracker.ChangeTrackingMethod(_markerlessTracking);
        }

        public void MarkerlessStartTapped()
        {
            if (!_kudanTracker.ArbiTrackIsTracking())
            {
                Vector3 floorPosition;
                Quaternion floorOrientation;

                _kudanTracker.FloorPlaceGetPose(out floorPosition, out floorOrientation);
                _kudanTracker.ArbiTrackStart(floorPosition, floorOrientation);
                markerlessStartButton.image.color = Color.red;
            }
            else
            {
                _kudanTracker.ArbiTrackStop();
                markerlessStartButton.image.color = Color.white;
            }
        }

        public void NextToScene()
        {
            SceneManager.LoadScene("SaveViewScene");
        }
    }
}