using System.Collections.Generic;
using Entitas;
using UnityEngine;
using System.Linq.Expressions;


public class ProcessMatchedSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    readonly Contexts _contexts;

    List<GameEntity> sameTypeEntities;
    List<GameEntity> entitiesToDestroy;

    private TileType? previousType;

    public ProcessMatchedSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _context = _contexts.game;

        sameTypeEntities = new List<GameEntity>();
        entitiesToDestroy = new List<GameEntity>();

        previousType = null;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllAnimationComplete);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        Debug.Log("Execute ProcessMatchedSystem" + entities.Count);

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
            entityToDestroy.isDestroyed = true;
        }
        entitiesToDestroy.Clear();
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
        entity = _context.GetTileWithPosition(new IntVector2D(x, y));
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