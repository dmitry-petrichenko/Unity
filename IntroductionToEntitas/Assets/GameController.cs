using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;

	void Start ()
	{
	    var contexts = Contexts.sharedInstance;

	    var entity = contexts.game.CreateEntity();

	    _systems = CreateSystems(contexts);
        _systems.Initialize();
	}

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializeHexagonGridSystem(contexts))
            ;
    }
}
