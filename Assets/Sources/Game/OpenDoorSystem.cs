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
            GameEntity doorEntity = button.doorEntity;
            DoorState state = doorEntity.door.state;

            switch (state)
            {
                case DoorState.Closed:
                    doorEntity.ReplaceDoor(DoorState.Opening);
                    doorEntity.AddTweenAnimation(MoveTo(doorEntity, -1.95f, DoorState.Open));
                    break;
                case DoorState.Open:
                    doorEntity.ReplaceDoor(DoorState.Closing);
                    doorEntity.AddTweenAnimation(MoveTo(doorEntity, 0f, DoorState.Closed));
                    break;
            }

            entity.isButtonTriggered = false;
        }
    }
    
    private LTDescr MoveTo(GameEntity entity, float height, DoorState endState)
    {
        return LeanTween.moveY(entity.view.value, height, 2f)
            .setOnComplete(() =>
            {
                entity.ReplaceDoor(endState);
                entity.RemoveTweenAnimation();
            });
    }
}
