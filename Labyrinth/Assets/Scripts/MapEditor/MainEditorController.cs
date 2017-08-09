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

    void Start()
    {
        _settingsList = new SettingsList();
        _settingsList.Initialize();
        ServiceLocator.InitializeSettings(_settingsList);

        _graphicsController = new EditorGraphicsController();
        _graphicsController.Initialize(gameObject, EmptySquare, CubeSuare);
        ServiceLocator.InitializeGraphicsController(_graphicsController);
        _graphicsController.TileClicked += TileClickHandler;
        _graphicsController.RightClicked += RightClickHandler;

        _mapInfoStoreController = new MapInfoStoreController();
        _mapInfoStoreController.Initialize();
        _mapTilesInfo = _mapInfoStoreController.UploadMapInfo("");

        _mapInfoInitializer = new MapInfoInitializer();
        _mapInfoInitializer.Initialize(_mapTilesInfo);
        //_mapInfoInitializer.Initialize(new IntVector2(20, 20));
        _mapTilesInfo = _mapInfoInitializer.MapTilesInfo;

        _mapViewController = new EditorMapViewController();
        _mapViewController.Initialize();
        _mapViewController.InitializeTiles(_mapTilesInfo);

        _cameraController = new CameraController();
        _cameraController.Initialize(Camera, 20);
        ServiceLocator.InitializeCameraController(_cameraController);

        IntVector2 position = new IntVector2(_mapTilesInfo.GetLength(0) / 4, _mapTilesInfo.GetLength(1) / 4);
        _cameraController.UpdateCurrentPosition(position);
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
        _mapInfoStoreController.SaveMapInfo(_mapInfoInitializer.MapTilesInfo, "");
    }

    private void TileClickHandler(IntVector2 position)
    {
        position = new IntVector2(position.x * 2, position.y * 2);
        _mapInfoInitializer.InitializeCube(position);
        _mapViewController.UpdateTile(position);
    }
}