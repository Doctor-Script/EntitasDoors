using Entitas.Unity;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Color color;

    private GameEntity buttonEntity;
    
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
        doorEntity.AddView(door);
        doorEntity.AddDoor(DoorState.Closed);
        door.Link(doorEntity);

        buttonEntity = gameContext.CreateEntity();
        buttonEntity.AddView(gameObject);
        buttonEntity.AddButton(doorEntity);
        gameObject.Link(buttonEntity);
    }

    void OnTriggerEnter(Collider other)
    {
        buttonEntity.isButtonTriggered = true;
    }
}
