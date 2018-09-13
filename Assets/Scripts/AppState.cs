using System;
using UniRx;

public enum AppState
{
    None,
    Normal,
    Small,
    Sector,
}

[Serializable]
public class AppStateReactiveProperty : ReactiveProperty<AppState>
{
    public AppStateReactiveProperty() { }
    public AppStateReactiveProperty(AppState initialState) : base(initialState) { }
}
