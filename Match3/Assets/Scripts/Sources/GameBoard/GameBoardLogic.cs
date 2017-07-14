using System;
using Entitas;
using UnityEngine;

public static class GameBoardLogic {

    public static int GetNextEmptyRow(Contexts contexts, IntVector2D position) {
        var globalSettings = contexts.gameState.globalSettings.value;
        position.y -= 1;
        if(position.x == -1 && position.y == 1)
             Debug.Log("y " + position.y + "x " + position.x);
        while(position.y >= globalSettings.startPositionY && GetEntitiesWithPosition(contexts, position)== null) {
            position.y -= 1;
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
}
