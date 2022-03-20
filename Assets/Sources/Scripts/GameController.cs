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
            .Add(new InputSystems(contexts))
            .Add(new GameSystems(contexts, playerAgent));// TODO Fix Agent dependency
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
