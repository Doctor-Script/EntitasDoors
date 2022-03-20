public class InputSystems : Feature
{
    public InputSystems(Contexts contexts) : base(nameof(InputSystems))
    {
        Add(new CollectPlayerInputSystem(contexts));
        Add(new ProcessPlayerInput(contexts));
    }
}