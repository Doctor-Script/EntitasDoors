using Entitas;
using UnityEngine;

public class CollectPlayerInputSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> players;
    
    public CollectPlayerInputSystem(Contexts contexts)
    {
        players = contexts.game.GetGroup(GameMatcher.Player);
    }
    
    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out hit))
            {
                GameEntity playerEntity = players.GetSingleEntity();
                playerEntity.player.Agent.destination = hit.point;
            }
        }
    }
}
