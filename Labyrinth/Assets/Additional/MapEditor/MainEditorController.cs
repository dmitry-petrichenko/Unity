using System.Collections.Generic;
using Additional;
using NSGraphics;
using UnityEngine;
using ZScripts;
using ZScripts.Map.Info;
using ZScripts.Map.View;
using ZScripts.Settings;
using CameraController = Additional.CameraController;

public class MainEditorController : MonoBehaviour
{
    public GameObject EmptySquare, CubeSuare;
    public Camera Camera;
    
    public static int SCALE = 2;

    private EditorMapViewController _mapViewController;
    private Dictionary<IntVector2, IMapTileInfo> _mapTilesInfo = new Dictionary<IntVector2, IMapTileInfo>();
    private IMapInfoInitializer _mapInfoInitializer;
    private IMapInfoStoreController _mapInfoStoreController;
    private EditorGraphicsController _graphicsController;
    private SettingsList _settingsList;
    private CameraController _cameraController;
    private IntVector2 _cameraPosition;

    void Start()
    {
        _settingsList = new SettingsList(null);
        _settingsList.Initialize();
        ServiceLocator.InitializeSettings(_settingsList);

        _graphicsController = new EditorGraphicsController();
        _graphicsController.Initialize(gameObject, EmptySquare, CubeSuare);
        MapServiceLocator.InitializeMapViewController(_graphicsController);
        _graphicsController.TileClicked += TileClickHandler;
        _graphicsController.RightClicked += RightClickHandler;

       
        _mapInfoInitializer = new MapInfoInitializer();
        _mapInfoStoreController = new MapInfoStoreController(_settingsList);
        //UPLOAD MAP FROM DISK
        //_mapTilesInfo = _mapInfoStoreController.UploadSectorData(new IntVector2(1, 0));
        //_mapInfoInitializer.InitializeSector(_mapTilesInfo);
        //------------------
        // INITIALIZE NEW MAP
        _mapInfoInitializer.CreateSector(new IntVector2(0, 0), new IntVector2(0, 0), new IntVector2(6, 6));
        _mapTilesInfo = _mapInfoInitializer.MapTilesInfo;
        //------------------
        
        _mapViewController = new EditorMapViewController();
        _mapViewController.Initialize();
        _mapViewController.InitializeTiles(_mapTilesInfo);

        _cameraController = new CameraController();
        _cameraController.Initialize(Camera, 20);
        ServiceLocator.InitializeCameraController(_cameraController);

        _cameraPosition = new IntVector2(0, 0);
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
        position = new IntVector2(position.x * SCALE, position.y * SCALE);
        _mapInfoInitializer.InitializePlane(position);
        _mapViewController.UpdateTile(position);
    }

    public void SaveMap()
    {
        _mapInfoStoreController.SaveSector(_mapInfoInitializer.SectorInfo, _mapInfoInitializer.MapTilesInfo);
    }

    private void TileClickHandler(IntVector2 position)
    {
        position = new IntVector2(position.x * SCALE, position.y * SCALE);
        _mapInfoInitializer.InitializeCube(position);
        _mapViewController.UpdateTile(position);
    }
}