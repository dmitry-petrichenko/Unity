using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddTilesViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public AddTilesViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.GameTile));
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

            rectTransform.sizeDelta = new Vector2(globalSettings.widthSpacing, globalSettings.heightSpacing);

            var tileViewBehaviour = tile.GetComponent<TileViewBehaviour>();
            tileViewBehaviour.image.rectTransform.sizeDelta = new Vector2(globalSettings.widthSpacing,
                globalSettings.heightSpacing);
            tileViewBehaviour.SetScale(new Vector2(0.55f, 0.55f));

            entity.AddView(tile);

            var position = new Vector2(entity.position.value.x * globalSettings.widthSpacing,
                entity.position.value.y * globalSettings.heightSpacing);

            rectTransform.anchoredPosition = position;
        }
        
        var completeEntity = _contexts.input.CreateEntity();
        completeEntity.isAllAnimationCompleteComponentI = true;
    }
}