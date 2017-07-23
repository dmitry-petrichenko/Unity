using Entitas;

public class CleanupInputSystem : ICleanupSystem
{
    private Contexts _contexts;
    
    public CleanupInputSystem (Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Cleanup()
    {
        var entities = _contexts.input.GetEntities();
        foreach (var e in entities)
        {
            _contexts.input.DestroyEntity(e);
        }
    }
}
