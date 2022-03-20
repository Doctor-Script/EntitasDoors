using Entitas;
using UnityEngine;

public class CollectPlayerInputSystem : IExecuteSystem
{
    private readonly InputContext inputContext;
    public CollectPlayerInputSystem(Contexts contexts)
    {
        inputContext = contexts.input;
    }
    
    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out hit))
            {
                InputEntity entity = inputContext.CreateEntity();
                entity.AddInput(hit.point);
            }
        }
    }
}