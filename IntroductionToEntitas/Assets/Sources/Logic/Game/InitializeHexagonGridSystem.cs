using Entitas;
using UnityEngine;

public class InitializeHexagonGridSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeHexagonGridSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        for (int i = -3; i < 3; i++)
        {
            for (int j = -7; j < 7; j++)
            {
                var entity = _contexts.game.CreateEntity();
                entity.AddPosition(new IntVector2(j, i));
                entity.isHexagon = true;
            }
        }
        
    }
}
