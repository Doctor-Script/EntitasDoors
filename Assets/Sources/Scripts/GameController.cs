using Entitas;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    [SerializeField] NavMeshAgent playerAgent;
    
    private Systems systems;
    private Contexts contexts;

    void Start()
    {
        contexts = Contexts.sharedInstance;
        systems = new Feature("Systems")
            .Add(new CollectPlayerInputSystem(contexts))
            
            .Add(new InitializePlayerSystem(contexts, playerAgent))// TODO Fix Agent dependency
            .Add(new OpenDoorSystem(contexts));
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
