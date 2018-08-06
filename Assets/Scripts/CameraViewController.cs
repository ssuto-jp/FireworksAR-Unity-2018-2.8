using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraViewController : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("SaveViewScene");
    }
}
