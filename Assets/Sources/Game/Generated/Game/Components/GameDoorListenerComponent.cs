//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DoorListenerComponent doorListener { get { return (DoorListenerComponent)GetComponent(GameComponentsLookup.DoorListener); } }
    public bool hasDoorListener { get { return HasComponent(GameComponentsLookup.DoorListener); } }

    public void AddDoorListener(System.Collections.Generic.List<IDoorListener> newValue) {
        var index = GameComponentsLookup.DoorListener;
        var component = (DoorListenerComponent)CreateComponent(index, typeof(DoorListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDoorListener(System.Collections.Generic.List<IDoorListener> newValue) {
        var index = GameComponentsLookup.DoorListener;
        var component = (DoorListenerComponent)CreateComponent(index, typeof(DoorListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDoorListener() {
        RemoveComponent(GameComponentsLookup.DoorListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDoorListener;

    public static Entitas.IMatcher<GameEntity> DoorListener {
        get {
            if (_matcherDoorListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DoorListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDoorListener = matcher;
            }

            return _matcherDoorListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddDoorListener(IDoorListener value) {
        var listeners = hasDoorListener
            ? doorListener.value
            : new System.Collections.Generic.List<IDoorListener>();
        listeners.Add(value);
        ReplaceDoorListener(listeners);
    }

    public void RemoveDoorListener(IDoorListener value, bool removeComponentWhenEmpty = true) {
        var listeners = doorListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveDoorListener();
        } else {
            ReplaceDoorListener(listeners);
        }
    }
}
