using Labyrinth;
using Labyrinth.Settings;
using Map;
using NSCameraController;
using NSGraphics;
using Units;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Plane, Cube, Square, Empty, Player;
    public Camera _camera;

    private MapInfoController _mapInfoController;
    private MapViewController _mapViewController;
    private GraphicsController _graphicsController;
    private CameraController _cameraController;
    private SettingsList _settingsList;
    private InputController _inputController;
    private UnitsController _unitsController;

    // Use this for initialization
    void Start()
    {
        _settingsList = new SettingsList();
        _settingsList.Initialize(Player);
        ServiceLocator.InitializeSettings(_settingsList);

        _cameraController = new CameraController();
        _cameraController.Initialize(_camera);
        ServiceLocator.InitializeCameraController(_cameraController);

        _graphicsController = new GraphicsController();
        _graphicsController.Initialize(gameObject, Plane, Cube, Square, Empty);
        ServiceLocator.InitializeGraphicsController(_graphicsController);

        _mapInfoController = new MapInfoController();
        _mapInfoController.Initialize();
        ServiceLocator.InitializeMapInfoController(_mapInfoController);

        _mapViewController = new MapViewController();
        _mapViewController.Initialize();
        ServiceLocator.InitializeMapViewController(_mapViewController);

        _unitsController = new UnitsController();
        _unitsController.Initializr();
        ServiceLocator.InitializeUnitsController(_unitsController);
        
        
        _inputController = new InputController();
        _inputController.Initialize();
        

        //InvokeRepeating("cl", 1f, 1f);
    }
}