using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ProcessSelectionSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;
    readonly Contexts _contexts;

    private List<GameEntity> _selectedEntities;

    public ProcessSelectionSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _contexts = contexts;
        _selectedEntities = new List<GameEntity>();
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Selected);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        /*
        foreach (var entity in entities)
        {
            entity.isDestroyed = true;
        }
        */
        
        //_selectedEntities.Add(entities[0]);

        foreach (var entity in entities)
        {
            _selectedEntities.Add(entity);
        }

        if (_selectedEntities.Count > 1)
        {
            var neibhourEntity =  GetSelectedNeighbourOfPosition(_selectedEntities[1].position.value);
            if (neibhourEntity != null)
            {
                ReplaceEntities();
                Debug.Log("ReplaceEntities");
                ResetSelectedEntities();
            }
            else
            {
                Debug.Log("no neibh");
                ResetSelectedEntities();
            }
            
        }

    }

    private void ReplaceEntities()
    {
        var entity1 = _selectedEntities[0];
        var entity2 = _selectedEntities[1];
        var tempPos = entity1.position.value;
        entity1.ReplacePosition(entity2.position.value);
        entity2.ReplacePosition(tempPos);
    }
    
    private void ResetSelectedEntities()
    {
        foreach (var entity in _selectedEntities)
        {
            entity.isSelected = false;
        }
        _selectedEntities = new List<GameEntity>();
    }

    private GameEntity GetSelectedNeighbourOfPosition(IntVector2D position)
    {
        var positionN = new IntVector2D(position.x, position.y + 1);
        if (IsSelectedOnPosition(positionN))
            return GameBoardLogic.GetEntitiesWithPosition(_contexts, positionN);
        
        positionN = new IntVector2D(position.x, position.y - 1);
        if (IsSelectedOnPosition(positionN))
            return GameBoardLogic.GetEntitiesWithPosition(_contexts, positionN);
        
        positionN = new IntVector2D(position.x + 1, position.y);
        if (IsSelectedOnPosition(positionN))
            return GameBoardLogic.GetEntitiesWithPosition(_contexts, positionN);
        
        positionN = new IntVector2D(position.x - 1, position.y);
        if (IsSelectedOnPosition(positionN))
            return GameBoardLogic.GetEntitiesWithPosition(_contexts, positionN);

        return null;
    }

    private bool IsSelectedOnPosition(IntVector2D position)
    {
        var entity = GameBoardLogic.GetEntitiesWithPosition(_contexts, position);
        if (entity != null && entity.isSelected)
        {
            return true;
        }

        return false;
    }
}
