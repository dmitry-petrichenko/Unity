using System.Collections.Generic;
using System.Linq.Expressions;
using Entitas;
using UnityEngine;

public sealed class FillSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;
    readonly Contexts _contexts;

    public FillSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.AnimationComplete, GameMatcher.AllAnimationComplete));
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        Debug.Log("Execute FILL_System");
        var globalSettings = _contexts.gameState.globalSettings.value;
        
        for (int column = globalSettings.startPositionX; column < globalSettings.endPositionX; column++) {
            var position = new IntVector2D(column, globalSettings.endPositionY);
        
            var nextRowPos = GameBoardLogic.GetNextEmptyRow(_contexts, position);
            while(nextRowPos != globalSettings.endPositionY) {
                GameBoardLogic.CreateRandomeTile(_contexts, column, nextRowPos);
                nextRowPos = GameBoardLogic.GetNextEmptyRow(_contexts, position);
            }
        }
    }
}
