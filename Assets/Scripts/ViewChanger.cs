using UnityEngine;

public class ViewChanger : SingletonMonoBehaviour<ViewChanger>
{
    [SerializeField] private GameObject captureView;
    [SerializeField] private GameObject saveView;

    public void ChangeView()
    {
        if (!saveView.activeInHierarchy)
        {
            saveView.SetActive(true);
        }
        else
        {
            saveView.SetActive(false);
        }
    }
}
