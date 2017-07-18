//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly StartFallSystemComponent startFallSystemComponent = new StartFallSystemComponent();

    public bool isStartFallSystem {
        get { return HasComponent(GameComponentsLookup.StartFallSystem); }
        set {
            if(value != isStartFallSystem) {
                if(value) {
                    AddComponent(GameComponentsLookup.StartFallSystem, startFallSystemComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.StartFallSystem);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStartFallSystem;

    public static Entitas.IMatcher<GameEntity> StartFallSystem {
        get {
            if(_matcherStartFallSystem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StartFallSystem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStartFallSystem = matcher;
            }

            return _matcherStartFallSystem;
        }
    }
}
