using System;

public static class ContextExtensions
{
    public static GameEntity CreateRandomeTile(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.isGameTile = true;
        entity.ReplacePosition(new IntVector2D(x, y));
        entity.AddGameTileType(
            InitializeTilesSystem._tipes[UnityEngine.Random.Range(0, InitializeTilesSystem._tipes.Length)]);
        return entity;
    }

    public static GameEntity GetTileWithPosition(this GameContext context, IntVector2D position)
    {
        var entities = context.GetEntitiesWithPosition(position);
        foreach (var entity in entities)
        {
            if (entity.isGameTile)
            {
                return entity;
            }
        }
        return null;
    }

    public static int GetNextEmptyRow(this GameContext context, IntVector2D position, Contexts contexts)
    {
        var globalSettings = contexts.gameState.globalSettings.value;
        position.y -= 1;
        if (position.y >= globalSettings.startPositionY)
        {
            if (context.GetTileWithPosition(position) == null)
            {
                return position.y;
            }
            if (context.GetTileWithPosition(position).isDestroyed)
            {
                return position.y;
            }
        }

        return position.y + 1;
    }

    public static void DoForEach(this GameContext context, Contexts contexts, Action<int, int> execute)
    {
        var globalSettings = contexts.gameState.globalSettings.value;
        for (int column = globalSettings.startPositionX; column < globalSettings.endPositionX; column++)
        {
            for (int row = globalSettings.startPositionY; row < globalSettings.endPositionY; row++)
            {
                execute(column, row);
            }
        }
    }
}