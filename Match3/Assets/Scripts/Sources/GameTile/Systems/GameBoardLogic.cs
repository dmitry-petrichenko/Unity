using Entitas;
using UnityEngine;

public static class GameBoardLogic {

    public static int GetNextEmptyRow(Contexts contexts, IntVector2D position) {
        var globalSettings = contexts.gameState.globalSettings.value;
        position.y -= 1;
        while(position.y >= (-globalSettings.height / 2) && GetEntitiesWithPosition(contexts, position)== null) {
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
}
