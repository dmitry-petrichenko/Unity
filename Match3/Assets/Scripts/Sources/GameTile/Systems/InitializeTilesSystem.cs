using System;
using Entitas;

public class InitializeTilesSystem : IInitializeSystem
{
    static readonly TileType[] _tipes = {
        TileType.Red,
        TileType.Green,
        TileType.Blue,
        TileType.Yellow
    };
    
    private Contexts _contexts;
    
    public InitializeTilesSystem (Contexts contexts)
    {
        _contexts = contexts;
    }
   
    public void Initialize()
    {
        var globalSettings = _contexts.gameState.globalSettings.value;
        var context = _contexts.game;
        
        var startPositionX = -globalSettings.width / 2;
        var endPositionX = globalSettings.width % 2 == 0 ? globalSettings.width / 2 : globalSettings.width / 2 + 1;
        var startPositionY = -globalSettings.height / 2;
        var endPositionY = globalSettings.height % 2 == 0 ? globalSettings.height / 2 : globalSettings.height / 2 + 1;
        
        for (int i = startPositionX; i < endPositionX; i++)
        {
            for (int j = startPositionY; j < endPositionY; j++)
            {
                var entity = context.CreateEntity();
                entity.AddPosition(new IntVector2D(i, j));
                entity.isGameTile = true;
                entity.AddGameTileType(_tipes[UnityEngine.Random.Range(0, _tipes.Length)]);
            }
        }
    }
}
