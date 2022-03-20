using System.Collections.Generic;
using Entitas;

public class OpenDoorSystem : ReactiveSystem<GameEntity>
{
    public OpenDoorSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.ButtonTriggered);
    }

    protected override bool Filter(GameEntity entity) => entity.isButtonTriggered;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            ButtonComponent button = entity.button;
            GameEntity doorEntity = button.DoorEntity;
            DoorState state = doorEntity.door.State;
            
            switch (state)
            {
                case DoorState.Closed:
                    doorEntity.ReplaceDoor(DoorState.Opening);
                    break;
                case DoorState.Open:
                    doorEntity.ReplaceDoor(DoorState.Closing);
                    break;
            }
            entity.isButtonTriggered = false;
        }
    }
}
