using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

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
        return entity.hasPosition && entity.isGameBoardSquare;
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        var backgroundSquarePrefab = _contexts.gameState.globalSettings.value.backgroundSquarePrefab;
        var uiRoot = _contexts.game.uiRoot.value;
        var globalSettings = _contexts.gameState.globalSettings.value;
        var addViewFlag = true;
        
        foreach (var entity in entities)
        {
            if (addViewFlag)
            {
                var square = GameObject.Instantiate(backgroundSquarePrefab, uiRoot);
                var rectTransform = (RectTransform) square.transform;
  
                var image = square.GetComponent<Image>();
                image.rectTransform.sizeDelta = new Vector2(globalSettings.widthSpacing, globalSettings.heightSpacing);

                entity.AddView(square);

                var position = new Vector2(entity.position.value.x * globalSettings.widthSpacing,
                    entity.position.value.y * globalSettings.heightSpacing);

                rectTransform.anchoredPosition = position;
            }
            addViewFlag = !addViewFlag;
        }
    }
}
