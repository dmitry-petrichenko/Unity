using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public sealed class FallSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;
    readonly Contexts _contexts;

    public FallSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameTile, GroupEvent.Removed);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        var globalSettings = _contexts.gameState.globalSettings.value;
        for (int column = -globalSettings.width / 2; column < globalSettings.width; column++) {
            for (int row = 0; row < globalSettings.height; row++) {
                var position = new IntVector2D(column, row);
                var entity = GameBoardLogic.GetEntitiesWithPosition(_contexts, position);
                if (entity != null)
                {
                    moveDown(entity, position);
                }
            }
        }
    }

    void moveDown(GameEntity e, IntVector2D position) {
        var nextRowPos = GameBoardLogic.GetNextEmptyRow(_contexts, position);
        if (nextRowPos != position.y) {
            e.ReplacePosition(new IntVector2D(position.x, nextRowPos));
        }
    }
}
