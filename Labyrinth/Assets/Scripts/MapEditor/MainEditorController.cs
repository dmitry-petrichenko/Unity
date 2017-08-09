using Labyrinth;
using Labyrinth.Settings;
using Map;
using NSCameraController;
using NSGraphics;
using UnityEngine;

public class MainEditorController : MonoBehaviour
{
	public GameObject EmptySquare, CubeSuare;
	public Camera Camera;

	private EditorMapViewController _mapViewController;
	private IMapTileInfo[,] _mapTilesInfo;
	private MapInfoInitializer _mapInfoInitializer;
	private MapInfoStoreController _mapInfoStoreController;
	private EditorGraphicsController _graphicsController;
	private SettingsList _settingsList;
	private CameraController _cameraController;
	
	void Start () {
		_settingsList = new SettingsList();
		_settingsList.Initialize();
		ServiceLocator.InitializeSettings(_settingsList);
		
		_graphicsController = new EditorGraphicsController();
		_graphicsController.Initialize(gameObject, EmptySquare, CubeSuare);
		ServiceLocator.InitializeGraphicsController(_graphicsController);
		
		_mapInfoStoreController = new MapInfoStoreController();
		_mapInfoStoreController.Initialize();
		_mapTilesInfo = _mapInfoStoreController.UploadMapInfo("");
		
		_mapViewController = new EditorMapViewController();
		_mapViewController.Initialize();
		_mapViewController.InitializeTiles(_mapTilesInfo);
		
		_cameraController = new CameraController();
		_cameraController.Initialize(Camera, 20);
		ServiceLocator.InitializeCameraController(_cameraController);
		
		IntVector2 position = new IntVector2(_mapTilesInfo.GetLength(0) / 4, _mapTilesInfo.GetLength(1) / 4);
		_cameraController.UpdateCurrentPosition(position);
		
		
	}
}
