using System;
using UnityEngine;
using Zenject;
using Labyrinth;
using Labyrinth.GameLoop;
using Labyrinth.Map;
using Labyrinth.Settings;
using NSCameraController;
using Units;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public GameObject Plane, Cube, Square, Empty, Player;
    public Camera _camera;
    
    private MapController _mapController;
    private MapViewController _mapViewController;
    private CameraController _cameraController;
    private SettingsList _settingsList;
    private InputController _inputController;
    private UnitsController _unitsController;
    private GameLoopController _gameLoopController;
    private MapGraphicsList _mapGraphicsList;
    private ActiveMapLocationController _activeMapLocationController;
    
    public event Action Updated;
    
    public override void InstallBindings()
    {
    }
    
    void Start()
    {
        
        _mapGraphicsList = new MapGraphicsList();
        _mapGraphicsList.Initialize(gameObject, Plane, Cube, Square, Empty);
        
        _settingsList = new SettingsList();
        _settingsList.Initialize(_mapGraphicsList, Player);
        ServiceLocator.InitializeSettings(_settingsList);

        _gameLoopController = new GameLoopController();
        _gameLoopController.Initialize(this);
        ServiceLocator.InitializeGameLoopController(_gameLoopController);

        _cameraController = new CameraController();
        _cameraController.Initialize(_camera);
        ServiceLocator.InitializeCameraController(_cameraController);

        _mapController = new MapController();
        _mapController.Initialize();
        ServiceLocator.InitializeMapViewController(_mapController);
        
        _unitsController = new UnitsController();
        _unitsController.Initilize();
        ServiceLocator.InitializeUnitsController(_unitsController);

        _inputController = new InputController();
        _inputController.Initialize();

        _activeMapLocationController = new ActiveMapLocationController();
        _activeMapLocationController.Initialize();

        //InvokeRepeating("cl", 1f, 1f);
    }

    void Update()
    {
        if (Updated != null)
            Updated();
    }
}