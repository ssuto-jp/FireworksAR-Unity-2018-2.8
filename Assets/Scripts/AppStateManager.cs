using UnityEngine;

public class AppStateManager : SingletonMonoBehaviour<AppStateManager>
{
    private AppStateReactiveProperty _currentState = new AppStateReactiveProperty(AppState.None);
    public AppStateReactiveProperty CurrentState { get { return _currentState; } }
}
