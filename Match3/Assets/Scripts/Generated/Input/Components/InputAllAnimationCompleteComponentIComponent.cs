//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly AllAnimationCompleteComponentI allAnimationCompleteComponentIComponent = new AllAnimationCompleteComponentI();

    public bool isAllAnimationCompleteComponentI {
        get { return HasComponent(InputComponentsLookup.AllAnimationCompleteComponentI); }
        set {
            if(value != isAllAnimationCompleteComponentI) {
                if(value) {
                    AddComponent(InputComponentsLookup.AllAnimationCompleteComponentI, allAnimationCompleteComponentIComponent);
                } else {
                    RemoveComponent(InputComponentsLookup.AllAnimationCompleteComponentI);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAllAnimationCompleteComponentI;

    public static Entitas.IMatcher<InputEntity> AllAnimationCompleteComponentI {
        get {
            if(_matcherAllAnimationCompleteComponentI == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AllAnimationCompleteComponentI);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAllAnimationCompleteComponentI = matcher;
            }

            return _matcherAllAnimationCompleteComponentI;
        }
    }
}
