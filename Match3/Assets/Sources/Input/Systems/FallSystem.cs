using System.Collections.Generic;
using Entitas;

public sealed class FallSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext _context;
    readonly Contexts _contexts;

    private bool _fallExecuted;

    public FallSystem(Contexts contexts) : base(contexts.input)
    {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AnyOf(InputMatcher.NextStepEvent));
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
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
            var completeEntity = _contexts.input.CreateEntity();
            completeEntity.isAllAnimationCompleteComponentI = true;
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
}