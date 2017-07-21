using System.Collections.Generic;
using Entitas;

public class DisplayTileTypeSystem : ReactiveSystem<GameEntity>
{
    public DisplayTileTypeSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.isGameTile;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.value.GetComponent<TileViewBehaviour>().SetType(entity.gameTileType.value);
        }
    }
}