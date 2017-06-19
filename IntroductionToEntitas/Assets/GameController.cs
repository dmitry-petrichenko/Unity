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
	    contexts.game.SetUiRoot(uiRoot);

	    var entity = contexts.game.CreateEntity();
	    
        _systems = CreateSystems(contexts);
        _systems.Initialize();
	}

    void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializeHexagonGridSystem(contexts))
            .Add(new CheckClickInputSystem(contexts))
            .Add(new AddHexagonViewSystem(contexts))
		    .Add(new DisplayHexagonTypeSystem(contexts))
            ;
    }
}
