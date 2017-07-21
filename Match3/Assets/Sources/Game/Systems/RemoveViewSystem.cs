using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;

public class RemoveViewSystem : ReactiveSystem<GameEntity>
{
    public RemoveViewSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Destroyed, GameMatcher.GameTile));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            destroyView(e.view);
            e.RemoveView();
        }
    }

    void destroyView(ViewComponent viewComponent)
    {
        viewComponent.value.DestroyGameObject();
    }
}