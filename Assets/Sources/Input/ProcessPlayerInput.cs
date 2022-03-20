using System.Collections.Generic;
using Entitas;

public class ProcessPlayerInput : ReactiveSystem<InputEntity>
{
    private readonly IGroup<GameEntity> players;

    public ProcessPlayerInput(Contexts contexts) : base(contexts.input)
    {
        players = contexts.game.GetGroup(GameMatcher.Player);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity) => entity.hasInput;

    protected override void Execute(List<InputEntity> entities)
    {
        InputEntity inputEntity = entities.SingleEntity();
        foreach (var gameEntity in players)
        {
            gameEntity.player.Agent.destination = inputEntity.input.Destination;
        }
        inputEntity.Destroy();
    }
}