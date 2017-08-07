using Labyrinth;
using Labyrinth.Settings;
using Map;
using NSCameraController;
using NSGraphics;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Plane, Cube, Square, Empty;
	public Camera _camera;
	
	private MapInfoController _mapInfoController;
	private MapViewController _mapViewController;
	private GraphicsController _graphicsController;
	private CameraController _cameraController;
	private SettingsList _settingsList;
	private InputController _inputController;
	
	// Use this for initialization
	void Start () {
		_settingsList = new SettingsList();
		_settingsList.Initialize();
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

		_inputController = new InputController();
		_inputController.Initialize();
		
		//InvokeRepeating("cl", 1f, 1f);
	}

}
