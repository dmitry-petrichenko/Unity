using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class AddHexagonViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public AddHexagonViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.Position));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isHexagon && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var hexagonPrefab = _contexts.game.globals.value.hexagonPrefab;
        var uiRoot = _contexts.game.uiRoot.value;
        var globals = _contexts.game.globals.value;

        foreach (var entity in entities)
        {
            var hexagon = GameObject.Instantiate(hexagonPrefab, uiRoot);
            var rectTransform = (RectTransform)hexagon.transform;
            entity.AddView(hexagon);

            var position = new Vector2(entity.position.value.x * globals.widthSpacing, entity.position.value.y * globals.heightSpacing);
            var isEven = entity.position.value.x % 2 == 0;
            var image = hexagon.GetComponent<Image>();
            
            if (isEven)
            {
                image.color = globals.evenColor;
            }
            else
            {
                position.y += globals.heightOffset;
                image.color = globals.oddColor;
            }
        
            rectTransform.anchoredPosition = position;
        }


    }
}
