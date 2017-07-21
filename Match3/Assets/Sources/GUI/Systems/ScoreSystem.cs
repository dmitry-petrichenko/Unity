using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + entities.Count);
    }

    public void Initialize()
    {
        _contexts.gameState.SetScore(0);
    }
}