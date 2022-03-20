using Entitas.Unity;
using UnityEngine;

public class ButtonDoorPairInitializer : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Color color;
    
    void Start()
    {
        SetColors();
        InitEntities();
    }

    private void SetColors()
    {
        GetComponent<Renderer>().material.color = color;
        door.GetComponentInChildren<Renderer>().material.color = color;
    }

    private void InitEntities()
    {
        GameContext gameContext = Contexts.sharedInstance.game;
        
        GameEntity doorEntity = gameContext.CreateEntity();
        doorEntity.AddDoor(false);
        door.Link(doorEntity);

        GameEntity buttonEntity = gameContext.CreateEntity();
        buttonEntity.AddButton(doorEntity.door);
        gameObject.Link(buttonEntity);
    }
}
