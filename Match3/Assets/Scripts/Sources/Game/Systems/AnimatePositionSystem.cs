using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity>, ICleanupSystem
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
        var globalSettings = _contexts.gameState.globalSettings.value;
        Tweener tweener = null;
        foreach (var e in entities)
        {
            var pos = e.position;

            var rectTransform = (RectTransform) e.view.value.transform;
            var position = new Vector2(pos.value.x * globalSettings.widthSpacing,
                pos.value.y * globalSettings.heightSpacing);

            if (rectTransform.anchoredPosition != position)
                tweener = rectTransform.DOAnchorPos(position, 0.1f).SetEase(Ease.Linear);
        }

        if (tweener != null)
            tweener.OnComplete(CompleteHandler);
    }

    void CompleteHandler()
    {
        var completeEntity = _context.CreateEntity();
        completeEntity.isAnimationComplete = true;
    }

    public void Cleanup()
    {
        var animationCompletes = _context.GetGroup(GameMatcher.AnimationComplete);
        foreach (var e in animationCompletes.GetEntities())
        {
            _context.DestroyEntity(e);
        }
    }
}