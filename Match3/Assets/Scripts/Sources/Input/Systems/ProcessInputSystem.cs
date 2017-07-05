using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessInputSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;
    
    public ProcessInputSystem (Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }
    
    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }
    
    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput;
    }
    
    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;
        
        foreach (var e in _contexts.game.GetEntities(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.GameTile))) {
            if (input.x == e.position.value.x && input.y == e.position.value.y)
            {
                e.isDestroyed = true;
            }
        }
    }
}
