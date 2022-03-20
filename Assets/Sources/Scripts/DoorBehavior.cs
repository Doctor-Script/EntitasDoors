using UnityEngine;

public class DoorBehavior : MonoBehaviour, IDoorListener
{
    private const float AnimationTime = 2f;
    
    [SerializeField] private GameObject movableDoor;
    [SerializeField] private float maxHeight = 1f;
    [SerializeField] private float minHeight = -.95f;
    
    public void OnDoor(GameEntity entity, DoorState state)
    {
        switch (state)
        {
            case DoorState.Opening:
                MoveTo(entity, minHeight, DoorState.Open);
                break;
            case DoorState.Closing:
                MoveTo(entity, maxHeight, DoorState.Closed);
                break;
        }
    }

    private void MoveTo(GameEntity entity, float height, DoorState endState)
    {
        LeanTween.moveY(movableDoor, height, AnimationTime)
            .setOnComplete(() => entity.ReplaceDoor(endState));
    }
}
