using Labyrinth;
using Labyrinth.Map;
using Labyrinth.Settings;
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
    private IntVector2 _cameraPosition;

    private string TEST_PATH = "/test.json";

    void Start()
    {
        _settingsList = new SettingsList();
        _settingsList.Initialize();
        ServiceLocator.InitializeSettings(_settingsList);

        _graphicsController = new EditorGraphicsController();
        _graphicsController.Initialize(gameObject, EmptySquare, CubeSuare);
        MapServiceLocator.InitializeMapViewController(_graphicsController);
        _graphicsController.TileClicked += TileClickHandler;
        _graphicsController.RightClicked += RightClickHandler;

        _mapInfoStoreController = new MapInfoStoreController();
        _mapInfoStoreController.Initialize();
        _mapTilesInfo = _mapInfoStoreController.UploadMapInfo(TEST_PATH);
        _mapInfoInitializer = new MapInfoInitializer();
        _mapInfoInitializer.Initialize(_mapTilesInfo);
        //_mapInfoInitializer.Initialize(new IntVector2(60, 60));
        _mapTilesInfo = _mapInfoInitializer.MapTilesInfo;

        _mapViewController = new EditorMapViewController();
        _mapViewController.Initialize();
        _mapViewController.InitializeTiles(_mapTilesInfo);

        _cameraController = new CameraController();
        _cameraController.Initialize(Camera, 20);
        ServiceLocator.InitializeCameraController(_cameraController);

        _cameraPosition = new IntVector2(_mapTilesInfo.GetLength(0) / 4, _mapTilesInfo.GetLength(1) / 4);
        _cameraController.UpdateCurrentPosition(_cameraPosition);


        MouseClickListener _mouseClickListener = gameObject.GetComponent<MouseClickListener>();
        _mouseClickListener.DownButtonClicked += DownButtonClicked;
        _mouseClickListener.UpButtonClicked += UpButtonClicked;
        _mouseClickListener.LeftButtonClicked += LeftButtonClicked;
        _mouseClickListener.RightButtonClicked += RightButtonClicked;
    }

    private void DownButtonClicked()
    {
        _cameraController.UpdateCurrentPosition(new IntVector2(_cameraPosition.x, _cameraPosition.y += 2));
    }
    
    private void UpButtonClicked()
    {
        _cameraController.UpdateCurrentPosition(new IntVector2(_cameraPosition.x, _cameraPosition.y -= 2));
    }
    
    private void LeftButtonClicked()
    {
        _cameraController.UpdateCurrentPosition(new IntVector2(_cameraPosition.x -= 2, _cameraPosition.y));
    }
    
    private void RightButtonClicked()
    {
        _cameraController.UpdateCurrentPosition(new IntVector2(_cameraPosition.x += 2, _cameraPosition.y));
    }

    private void RightClickHandler(IntVector2 position)
    {
        position = new IntVector2(position.x * 2, position.y * 2);
        _mapInfoInitializer.InitializeSquare(position);
        _mapInfoInitializer.InitializeSquare(new IntVector2(position.x + 1, position.y));
        _mapInfoInitializer.InitializeSquare(new IntVector2(position.x, position.y + 1));
        _mapInfoInitializer.InitializeSquare(new IntVector2(position.x + 1, position.y + 1));
        _mapViewController.UpdateTile(position);
    }

    public void SaveMap()
    {
        _mapInfoStoreController.SaveMapInfo(_mapInfoInitializer.MapTilesInfo, TEST_PATH);
    }

    private void TileClickHandler(IntVector2 position)
    {
        position = new IntVector2(position.x * 2, position.y * 2);
        _mapInfoInitializer.InitializeCube(position);
        _mapViewController.UpdateTile(position);
    }
}