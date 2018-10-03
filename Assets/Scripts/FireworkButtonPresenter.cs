using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class FireworkButtonPresenter : MonoBehaviour
{
    List<FireworkButton> fireworkButtons;

    private void Start()
    {
        fireworkButtons = GetComponentsInChildren<FireworkButton>().ToList();

        //Model => View
        AppStateManager.Instance.CurrentState
            .Subscribe(state =>
            {
                foreach (var button in fireworkButtons)
                {
                    button.ChangeFirework(state);
                }
            });

        //View => Model      
        foreach (var button in fireworkButtons)
        {
            button.OnClickAsObservable
                .Subscribe(buttonType =>
                {
                    if (AppStateManager.Instance.CurrentState.Value == buttonType)
                    {
                        AppStateManager.Instance.CurrentState.Value = AppState.None;
                    }
                    else
                    {
                        AppStateManager.Instance.CurrentState.Value = buttonType;
                    }
                })
                .AddTo(gameObject);
        }
    }
}
