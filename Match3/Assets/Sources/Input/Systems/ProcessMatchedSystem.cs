using System.Collections.Generic;
using Entitas;
using UnityEngine;
using System.Linq.Expressions;


public class ProcessMatchedSystem : ReactiveSystem<InputEntity>
{
    readonly InputContext _context;
    readonly Contexts _contexts;

    List<GameEntity> sameTypeEntities;
    List<GameEntity> entitiesToDestroy;

    private bool _somethingDestroyed;

    private TileType? previousType;

    public ProcessMatchedSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _context = _contexts.input;

        sameTypeEntities = new List<GameEntity>();
        entitiesToDestroy = new List<GameEntity>();

        previousType = null;
    }

    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllAnimationCompleteComponentI);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        //Debug.Log("Execute ProcessMatchedSystem");
        _somethingDestroyed = false;
        
        entitiesToDestroy.Clear();
        var globalSettings = _contexts.gameState.globalSettings.value;
        for (int column = globalSettings.startPositionX; column < globalSettings.endPositionX; column++)
        {
            for (int row = globalSettings.startPositionY; row < globalSettings.endPositionY; row++)
            {
                Action(column, row);
            }
            previousType = null;
        }

        for (int row = globalSettings.startPositionY; row < globalSettings.endPositionY; row++)
        {
            for (int column = globalSettings.startPositionX; column < globalSettings.endPositionX; column++)
            {
                Action(column, row);
            }
            previousType = null;
        }

        AddEntitiesToDestroy();

        foreach (var entityToDestroy in entitiesToDestroy)
        { 
            _somethingDestroyed = true;
            entityToDestroy.isDestroyed = true;
        }
        entitiesToDestroy.Clear();

        if (_somethingDestroyed)
        {
            var nextStepEntity = _contexts.input.CreateEntity();
            nextStepEntity.isNextStepEvent = true;
        }

    }

    void AddEntitiesToDestroy()
    {
        if (sameTypeEntities.Count >= 3)
        {
            foreach (var sameTypeEntity in sameTypeEntities)
            {
                entitiesToDestroy.Add(sameTypeEntity);
            }
        }
        sameTypeEntities.Clear();
    }

    void Action(int x, int y)
    {
        GameEntity entity;
        entity = _contexts.game.GetTileWithPosition(new IntVector2D(x, y));
        if (entity != null)
        {
            if (previousType != entity.gameTileType.value)
            {
                AddEntitiesToDestroy();
                sameTypeEntities.Add(entity);
                previousType = entity.gameTileType.value;
            }
            else
            {
                sameTypeEntities.Add(entity);
            }
        }
    }
}