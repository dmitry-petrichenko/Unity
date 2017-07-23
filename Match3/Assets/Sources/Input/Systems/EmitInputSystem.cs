using Entitas;
using UnityEngine;

public class EmitInputSystem : IExecuteSystem
{
    readonly InputContext _context;
    readonly IGroup<InputEntity> _inputs;
    private GlobalSettings _globalSettings;
    private RectTransform _uiRoot;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;

        _inputs = _context.GetGroup(InputMatcher.Input);
        _globalSettings = contexts.gameState.globalSettings.value;
        _uiRoot = contexts.game.uiRoot.value;
    }

    public void Execute()
    {
        var input = Input.GetMouseButtonDown(0); //Input.GetKeyDown("b");

        if (input)
        {
            var position = Input.mousePosition - _uiRoot.position;
            var x = (int) Mathf.Round(position.x / _globalSettings.widthSpacing);
            var y = (int) Mathf.Round(position.y / _globalSettings.heightSpacing);

            _context.CreateEntity()
                .AddInput(x, y);
        }
    }
}