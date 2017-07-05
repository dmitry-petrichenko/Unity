using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GlobalSettings globalSettings;
    public RectTransform uiRoot;
    
    private Systems _systems;
    private Contexts _contexts;

    private bool InitializeGlobalSettings;

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
        if (!InitializeGlobalSettings)
        {
            _contexts.gameState.globalSettings.value.Initialize();
        }
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
                .Add(new InitializeGameBoardSystem(contexts))
                .Add(new AddGameBorderViewSystem(contexts))
                
                .Add(new InitializeTilesSystem(contexts))
                .Add(new AddTilesViewSystem(contexts))
                .Add(new DisplayTileTypeSystem(contexts))
            
                .Add(new ScoreSystem(contexts))
                .Add(new EmitInputSystem(contexts))
                .Add(new ProcessInputSystem(contexts))
                
                .Add(new RemoveViewSystem(contexts))
                .Add(new DestroySystem(contexts))
            ;
    }
}