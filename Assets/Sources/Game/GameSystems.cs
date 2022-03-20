using UnityEngine.AI;

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts, NavMeshAgent playerAgent) : base(nameof(GameSystems))
    {
        Add(new InitializePlayerSystem(contexts, playerAgent));
        Add(new GameEventSystems(contexts));
        Add(new OpenDoorSystem(contexts));
    }
}
