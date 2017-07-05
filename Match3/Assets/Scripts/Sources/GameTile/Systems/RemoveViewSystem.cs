using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

public class RemoveViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public RemoveViewSystem (Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
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
        foreach (var e in entities) {
            destroyView(e.view);
            e.RemoveView();
        }
    }
    
    void destroyView(ViewComponent viewComponent) {
        Debug.Log(viewComponent);
        
        viewComponent.value.DestroyGameObject();//.enabled = false;
        
    }
}
