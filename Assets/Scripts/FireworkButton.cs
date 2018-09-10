using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class FireworkButton : MonoBehaviour
{
    [SerializeField] private AppState _buttonType;
    [SerializeField] private Text text;

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
        switch (currentState)
        {
            case AppState.Normal:
                text.text = "Normal";
                break;
            case AppState.Star:
                text.text = "Star";
                break;
            case AppState.Line:
                text.text = "Line";
                break;
        }
    }
}
