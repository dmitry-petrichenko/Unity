using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public RectTransform uiRoot;
    public Globals globals;

    private Systems _systems;

	void Start ()
	{
	    var contexts = Contexts.sharedInstance;

	   contexts.game.SetGlobals(globals);

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
