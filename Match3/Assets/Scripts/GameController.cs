using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GlobalSettings globalSettings;
    public RectTransform uiRoot;
    
    private Systems _systems;
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;

        _contexts.gameState.SetGlobalSettings(globalSettings);
       
        _contexts.game.SetUiRoot(uiRoot);

        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
                .Add(new InitializeSystem(contexts))
                .Add(new InitializeGameBoardSystem(contexts))
                .Add(new AddGameBorderViewSystem(contexts))
            ;
    }
}