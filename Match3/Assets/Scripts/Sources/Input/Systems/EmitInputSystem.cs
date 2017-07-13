using Entitas;
using UnityEngine;

public class EmitInputSystem : IExecuteSystem, ICleanupSystem
{
    readonly InputContext _contexts;
    readonly IGroup<InputEntity> _inputs;
    private GlobalSettings _globalSettings;
    private RectTransform _uiRoot;

    public EmitInputSystem(Contexts contexts)
    {
        _contexts = contexts.input;
        _inputs = _contexts.GetGroup(InputMatcher.Input);
        _globalSettings = contexts.gameState.globalSettings.value;
        _uiRoot = contexts.game.uiRoot.value;
    }

    public void Execute()
    {
        var input = Input.GetMouseButtonDown(0);//Input.GetKeyDown("b");

        if (input)
        {
            var position = Input.mousePosition - _uiRoot.position;
            var x = (int)Mathf.Round(position.x / _globalSettings.widthSpacing);
            var y = (int)Mathf.Round(position.y / _globalSettings.heightSpacing);

            _contexts.CreateEntity()
                .AddInput(x, y);
        }
    }

    public void Cleanup()
    {
        foreach (var e in _inputs.GetEntities())
        {
            _contexts.DestroyEntity(e);
        }
    }
}