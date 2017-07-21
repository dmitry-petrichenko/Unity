using System;
using Entitas;

public class InitializeTilesSystem : IInitializeSystem
{
    public static readonly TileType[] _tipes =
    {
        //todo
        TileType.Red,
        TileType.Green,
        TileType.Blue,
        TileType.Yellow
    };

    private Contexts _contexts;
    private GameContext _context;

    public InitializeTilesSystem(Contexts contexts)
    {
        _contexts = contexts;
        _context = _contexts.game;
    }

    public void Initialize()
    {
        _context.DoForEach(_contexts, Action);
    }

    void Action(int column, int row)
    {
        var entity = _context.CreateEntity();
        entity.AddPosition(new IntVector2D(column, row));
        entity.isGameTile = true;
        entity.AddGameTileType(_tipes[UnityEngine.Random.Range(0, _tipes.Length)]);
    }
}