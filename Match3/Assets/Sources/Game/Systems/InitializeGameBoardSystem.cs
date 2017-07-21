using Entitas;

public class InitializeGameBoardSystem : IInitializeSystem
{
    private Contexts _contexts;
    private GameContext _context;

    public InitializeGameBoardSystem(Contexts contexts)
    {
        _contexts = contexts;
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.DoForEach(_contexts, Action);
    }

    void Action(int column, int row)
    {
        var entity = _context.CreateEntity();
        entity.AddPosition(new IntVector2D(column, row));
        entity.isGameBoardSquare = true;
    }
}