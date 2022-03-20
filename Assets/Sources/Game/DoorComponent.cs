using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum DoorState { Closed, Open, Opening, Closing }

[Game, Event(EventTarget.Self)]
public class DoorComponent : IComponent
{
    public DoorState State;
}
