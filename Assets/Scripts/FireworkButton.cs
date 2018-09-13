using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class FireworkButton : MonoBehaviour
{
    [SerializeField] private AppState _buttonType;
    [SerializeField] private GameObject[] fireworkEffects;
    //[SerializeField] private Text text;//debug

    private Subject<AppState> _onClickedButton = new Subject<AppState>();
    public IObservable<AppState> OnClickAsObservable
    {
        get { return _onClickedButton; }
    }

    public void OnInputClicked()
    {
        _onClickedButton.OnNext(_buttonType);
    }

    public void ChangeFirework(AppState currentState)
    {
        StartCoroutine(ChangeFireworkCoroutine(currentState));
    }

    private IEnumerator ChangeFireworkCoroutine(AppState state)
    {
        foreach (var effects in fireworkEffects)
        {
            effects.SetActive(false);
        }

        yield return new WaitForEndOfFrame();

        switch (state)
        {
            case AppState.Normal:
                //text.text = "Normal";
                fireworkEffects[0].SetActive(true);
                break;
            case AppState.Small:
                //text.text = "Star";
                fireworkEffects[1].SetActive(true);
                break;
            case AppState.Sector:
                //text.text = "Sector";
                fireworkEffects[2].SetActive(true);
                break;
        }
    }
}
