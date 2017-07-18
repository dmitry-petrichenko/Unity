using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    readonly Contexts _contexts;

    public AnimatePositionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.GameTile));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        Debug.Log("Execute AnimatePositionSystem");
        var globalSettings = _contexts.gameState.globalSettings.value;
        Tweener tweener = null;
        foreach (var e in entities)
        {
            var pos = e.position;
            var isTopRow = pos.value.y == globalSettings.height - 1;
            if (isTopRow)
            {
                e.view.value.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 1);
            }
            var rectTransform = (RectTransform) e.view.value.transform;
            var position = new Vector2(pos.value.x * globalSettings.widthSpacing,
                pos.value.y * globalSettings.heightSpacing);

            tweener = rectTransform.DOAnchorPos(position, 2.0f).SetEase(Ease.Linear);
        }

        if (tweener != null)
            tweener.OnComplete(CompleteHandler);
    }

    void CompleteHandler()
    {
        Debug.Log("anim co");
        var completeEntity = _context.CreateEntity();
        completeEntity.isAnimationComplete = true;
    }
}