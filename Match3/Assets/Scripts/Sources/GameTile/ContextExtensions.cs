public static class ContextExtensions
{
     public static GameEntity CreateRandomeTile(this GameContext context, int x, int y)
     {
          var entity = context.CreateEntity();
          entity.isGameTile = true;
          entity.ReplacePosition(new IntVector2D(x, y));
          entity.AddGameTileType(InitializeTilesSystem._tipes[UnityEngine.Random.Range(0, InitializeTilesSystem._tipes.Length)]);
          return entity;
     }
}