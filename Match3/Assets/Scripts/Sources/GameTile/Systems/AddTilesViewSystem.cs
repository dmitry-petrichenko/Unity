using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddTilesViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public AddTilesViewSystem (Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    
    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.GameTile));
    }
    
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.isGameTile;
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        var tileViewPrefab = _contexts.gameState.globalSettings.value.tileViewPrefab;
        var uiRoot = _contexts.game.uiRoot.value;
        var globalSettings = _contexts.gameState.globalSettings.value;
        
        foreach (var entity in entities)
        {
            var tile = GameObject.Instantiate(tileViewPrefab, uiRoot);
            var rectTransform = (RectTransform) tile.transform;

            var rectTransform1 = uiRoot.GetComponent<RectTransform>();
            //Debug.Log(rectTransform1.rect.width);
            var temp = rectTransform1.rect.width / globalSettings.width;

            var scaleW = temp / globalSettings.widthSpacing;
            Debug.Log(rectTransform1.rect.width + " " + scaleW + " " +temp.ToString());
            
            entity.AddView(tile);

            var position = new Vector2(entity.position.value.x * globalSettings.widthSpacing * scaleW,
                entity.position.value.y * globalSettings.heightSpacing);

            rectTransform.anchoredPosition = position;
        }
    }
}
