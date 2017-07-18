using System.Collections.Generic;
using Entitas;
using UnityEditorInternal;
using UnityEngine;

public sealed class FallSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;
    readonly Contexts _contexts;

    private bool _fallExecuted;

    public FallSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.AnimationComplete, GameMatcher.Destroyed, GameMatcher.StartFallSystem));
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _fallExecuted = false;
        Debug.Log("Execute FallSystem");
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
            Debug.Log("No fall executed / All animation complete");
            var completeEntity = _context.CreateEntity();
            completeEntity.isAllAnimationComplete = true;
        }
    }
    
    void Action(int column, int row)
    {
        var position = new IntVector2D(column, row);
        var entity = GameBoardLogic.GetEntitiesWithPosition(_contexts, position);
        if (entity != null)
        {
            moveDown(entity, position);
        } 
        

    }

    void moveDown(GameEntity e, IntVector2D position) {
        var nextRowPos = GameBoardLogic.GetNextEmptyRow(_contexts, position);
        if (nextRowPos != position.y)
        {
            _fallExecuted = true;
            Debug.Log("e.ReplacePosition(" + position.x + " " + position.y + "on" + position.x + " " + nextRowPos);
            e.ReplacePosition(new IntVector2D(position.x, nextRowPos));
        }
        
    }
}
