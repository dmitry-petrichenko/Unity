using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class DisplaySelectionViewSystem : ReactiveSystem<GameEntity>
{
    public DisplaySelectionViewSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Selected, GroupEvent.AddedOrRemoved);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.value.GetComponent<TileViewBehaviour>().SetSelected(entity.isSelected);
        }
    }
}