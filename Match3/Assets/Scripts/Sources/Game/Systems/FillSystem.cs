using System.Collections.Generic;
using System.Linq.Expressions;
using Entitas;
using UnityEngine;

public sealed class FillSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    readonly GameContext _context;
    readonly Contexts _contexts;
    private bool _tilesCreated;

    public FillSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.AnimationComplete,
            GameMatcher.AllAnimationComplete));
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _tilesCreated = false;
        var globalSettings = _contexts.gameState.globalSettings.value;

        for (int column = globalSettings.startPositionX; column < globalSettings.endPositionX; column++)
        {
            var position = new IntVector2D(column, globalSettings.endPositionY);

            var nextRowPos = _context.GetNextEmptyRow(position, _contexts);
            if (nextRowPos != globalSettings.endPositionY)
            {
                _tilesCreated = true;
                _context.CreateRandomeTile(column, globalSettings.endPositionY);
            }
        }

        if (_tilesCreated)
        {
            var completeEntity = _context.CreateEntity();
            completeEntity.isStartFallSystem = true;
            //Debug.Log("Execute FILL_System");
        }
    }

    public void Cleanup()
    {
        var startFalEntities = _context.GetGroup(GameMatcher.StartFallSystem);
        foreach (var e in startFalEntities.GetEntities())
        {
            _context.DestroyEntity(e);
        }
    }
}