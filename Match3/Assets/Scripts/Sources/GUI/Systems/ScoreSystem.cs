using System.Collections.Generic;
using Entitas;

public class ScoreSystem : ReactiveSystem<InputEntity>, IInitializeSystem
{
    private Contexts _contexts;
    
    public ScoreSystem (Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }
    
    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }
    
    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    public void Initialize()
    {
        _contexts.gameState.SetScore(0);
    }
    
    protected override void Execute(List<InputEntity> entities)
    {
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + entities.Count);
    }
}
