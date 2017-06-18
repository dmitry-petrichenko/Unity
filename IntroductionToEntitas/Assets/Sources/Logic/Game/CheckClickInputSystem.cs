using System.Linq;
using Entitas;
using UnityEngine;

public class CheckClickInputSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _hexesGroup;

    public CheckClickInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _hexesGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hexes = _hexesGroup.GetEntities();
            var mousePosition = Input.mousePosition;

            var clickHex = hexes.OrderBy(x => (x.view.value.transform.position - mousePosition).sqrMagnitude)
                .FirstOrDefault(
                    x => (x.view.value.transform.position - mousePosition).magnitude <
                         _contexts.game.globals.value.clickRadius);

            Debug.Log(clickHex);
        }
    }
}
