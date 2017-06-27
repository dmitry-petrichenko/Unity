using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddGameBorderViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public AddGameBorderViewSystem (Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    
    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position));
    }
    
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition;
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        var backgroundSquarePrefab = _contexts.gameState.globalSettings.value.backgroundSquarePrefab;
        var uiRoot = _contexts.game.uiRoot.value;
        var globalSettings = _contexts.gameState.globalSettings.value;
        
        foreach (var entity in entities)
        {
            var square = GameObject.Instantiate(backgroundSquarePrefab, uiRoot);
            var rectTransform = (RectTransform) square.transform;
            entity.AddView(square);
            
            var position = new Vector2(entity.position.value.x * globalSettings.widthSpacing,
                entity.position.value.y * globalSettings.heightSpacing);

            rectTransform.anchoredPosition = position;
        }
    }
}
