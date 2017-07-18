using System;
using Entitas;
using UnityEngine;

public static class GameBoardLogic {

    public static int GetNextEmptyRow(Contexts contexts, IntVector2D position) {
        var globalSettings = contexts.gameState.globalSettings.value;
        position.y -= 1;
        if (position.y >= globalSettings.startPositionY && GetEntitiesWithPosition(contexts, position)== null) {
           return position.y;
        }

        return position.y + 1;
    }

    public static GameEntity GetEntitiesWithPosition(Contexts contexts, IntVector2D position)
    {
        foreach (var e in contexts.game.GetEntities(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.GameTile))) {
            if (position.x == e.position.value.x && position.y == e.position.value.y)
            {
                return e;
            }
        }
        return null;
    }

    public static void DoForEach(Contexts contexts, Action<int, int> execute)
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

    public static GameEntity CreateRandomeTile(Contexts contexts, int x, int y)
    {
        var globalSettings = contexts.gameState.globalSettings.value;
        var context = contexts.game;
        var entity = context.CreateEntity();
        //entity.AddPosition(new IntVector2D(x,  globalSettings.endPositionY));
        entity.isGameTile = true;
        entity.ReplacePosition(new IntVector2D(x, y));
        entity.AddGameTileType(InitializeTilesSystem._tipes[UnityEngine.Random.Range(0, InitializeTilesSystem._tipes.Length)]);
        return entity;
    }
}
