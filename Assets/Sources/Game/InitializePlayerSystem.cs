using Entitas;
using Entitas.Unity;
using UnityEngine.AI;

public class InitializePlayerSystem : IInitializeSystem
{
    private readonly GameContext gameContext;
    private readonly NavMeshAgent playerAgent;

    public InitializePlayerSystem(Contexts contexts, NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        gameContext = contexts.game;
    }
    
    public void Initialize()
    {
        GameEntity entity = gameContext.CreateEntity();
        entity.AddPlayer(playerAgent);
        playerAgent.gameObject.Link(entity);
    }
}
