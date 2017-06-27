using Entitas;

public class InitializeGameBoardSystem : IInitializeSystem
{
    private Contexts _contexts;
    
    public InitializeGameBoardSystem (Contexts contexts)
    {
        _contexts = contexts;
    }
   
    public void Initialize()
    {
        var globalSettings = _contexts.gameState.globalSettings.value;
        var context = _contexts.game;

        for (int i = 0; i < globalSettings.height; i++)
        {
            for (int j = 0; j < globalSettings.width; j++)
            {
                var entity = context.CreateEntity();
                entity.AddPosition(new IntVector2D(j, i));
            }
        }
    }
}
