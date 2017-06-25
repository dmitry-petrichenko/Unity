using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;
    
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Match3")
            .Add(new InitializeSystem(contexts))
            ;
    }
}
