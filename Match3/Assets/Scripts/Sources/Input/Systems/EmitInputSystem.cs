using Entitas;
using UnityEngine;

public class EmitInputSystem : IExecuteSystem, ICleanupSystem
{
    readonly InputContext _contexts;
    readonly IGroup<InputEntity> _inputs;

    public EmitInputSystem(Contexts contexts)
    {
        _contexts = contexts.input;
        _inputs = _contexts.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
        var input = Input.GetKeyDown("b");//Input.GetMouseButton(0);

        if (input)
        {
            //var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
           // if (hit.collider != null)
           // {
              //  var pos = hit.collider.transform.position;

                _contexts.CreateEntity()
                    .AddInput((int) 0, (int) 0);//.AddInput((int) pos.x, (int) pos.y);
            //}
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