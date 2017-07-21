using System.Collections.Generic;
using Entitas;
using UnityEditorInternal;
using UnityEngine;

public sealed class FallSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    readonly GameContext _context;
    readonly Contexts _contexts;

    private bool _fallExecuted;

    public FallSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.AnimationComplete, GameMatcher.Destroyed,
            GameMatcher.StartFallSystem));
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _fallExecuted = false;
        var globalSettings = _contexts.gameState.globalSettings.value;
        for (int column = globalSettings.startPositionX; column < globalSettings.endPositionX; column++)
        {
            for (int row = globalSettings.startPositionY; row < globalSettings.endPositionY + 1; row++)
            {
                Action(column, row);
            }
        }

        if (!_fallExecuted)
        {
            var completeEntity = _context.CreateEntity();
            completeEntity.isAllAnimationComplete = true;
        }
    }

    void Action(int column, int row)
    {
        var position = new IntVector2D(column, row);
        var entity = _context.GetTileWithPosition(position);

        if (entity != null && !entity.isDestroyed)
        {
            moveDown(entity, position);
        }
    }

    void moveDown(GameEntity e, IntVector2D position)
    {
        var nextRowPos = _context.GetNextEmptyRow(position, _contexts);
        if (nextRowPos != position.y)
        {
            _fallExecuted = true;
            e.ReplacePosition(new IntVector2D(position.x, nextRowPos));
        }
    }

    public void Cleanup()
    {
        var animationCompletes = _context.GetGroup(GameMatcher.AllAnimationComplete);
        foreach (var e in animationCompletes.GetEntities())
        {
            _context.DestroyEntity(e);
        }
    }
}