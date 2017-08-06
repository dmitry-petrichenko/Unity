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

	private int g;
	
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
		
		
		//---
		ISettings set = ServiceLocator.GetSettings();
		IntVector2 pos = new IntVector2(0, 0);
		_mapViewController.UpdateCurrentPosition(pos);
		_cameraController.UpdateCurrentPosition(pos);
		//_cameraController.UpdateCurrentPosition(new IntVector2(pos.x + set.ActiveAreaSize / 2, pos.y + set.ActiveAreaSize / 2));
		g = 0;
		InvokeRepeating("cl", 1f, 1f);

	}

	private void cl()
	{
		g++;
		IntVector2 pos = new IntVector2(g, 0);
		ISettings set = ServiceLocator.GetSettings();
		_mapViewController.UpdateCurrentPosition(pos);
		_cameraController.UpdateCurrentPosition(pos);
		//_cameraController.UpdateCurrentPosition(new IntVector2(pos.x + set.ActiveAreaSize / 2, pos.y + set.ActiveAreaSize / 2));
		Debug.Log(g);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
