using System.Collections.Generic;
using Entitas;

public sealed class FillSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext _context;
    readonly Contexts _contexts;
    private bool _tilesCreated;

    public FillSystem(Contexts contexts) : base(contexts.input)
    {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AnyOf(InputMatcher.NextStepEvent,
            InputMatcher.AllAnimationCompleteComponentI));
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
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
            var nextStepEvent = _contexts.input.CreateEntity();
            nextStepEvent.isNextStepEvent = true;
        }
    }
}