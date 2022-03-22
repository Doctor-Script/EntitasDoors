using Entitas;

public enum DoorState { Closed, Open, Opening, Closing }

[Game]
public class DoorComponent : IComponent
{
    public DoorState state;
}
