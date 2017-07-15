using System.Collections.Generic;
using Entitas;
using UnityEditorInternal;

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
        GameBoardLogic.DoForEach(_contexts, Action);   
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
            e.ReplacePosition(new IntVector2D(position.x, nextRowPos));
        }
    }
}