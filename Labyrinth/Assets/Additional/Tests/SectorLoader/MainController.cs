using System.Collections.Generic;
using UnityEngine;
using ZScripts;
using ZScripts.Map.Info;
using ZScripts.Map.View;
using ZScripts.Settings;
using ZScripts.Units;

namespace Additional.Tests.SectorLoader
{
    public class MainController : MonoBehaviour
    {
        public GameObject PlaneSquare, CubeSuare, VisibleSquare;
        public Camera Camera;

        public static int SCALE = 2;

        private const int SECTOR_SIZE = 3;

        private MapViewController _mapViewController;
        private Dictionary<IntVector2, IMapTileInfo> _mapTilesInfo = new Dictionary<IntVector2, IMapTileInfo>();
        private ISectorInfo _sectorInfo;
        private IMapInfoInitializer _mapInfoInitializer;
        private IMapInfoStoreController _mapInfoStoreController;
        private GraphicsController _graphicsController;
        private SettingsList _settingsList;
        private CameraController _cameraController;
        private IntVector2 _cameraPosition;
        private MapSectorController _sectorController;
        private UnitsControllerMock _unitsControllerMock;
        
        void Start()
        {
            _settingsList = new SettingsList(null);
            _settingsList.Initialize();
            ServiceLocator.InitializeSettings(_settingsList);

            _graphicsController = new GraphicsController();
            _graphicsController.Initialize(gameObject, PlaneSquare, CubeSuare, VisibleSquare);
            MapServiceLocator.InitializeSectorGraphicsController(_graphicsController);
            _graphicsController.TileClicked += TileClickHandler;
            _graphicsController.RightClicked += RightClickHandler;

            _mapInfoInitializer = new MapInfoInitializer();
            _mapInfoStoreController = new MapInfoStoreController(_settingsList);
            //UPLOAD MAP FROM DISK
            _mapTilesInfo = _mapInfoStoreController.UploadSectorData(new IntVector2(0, 0));
            _sectorInfo = _mapInfoStoreController.UploadSectorInfo(new IntVector2(0, 0));
            _mapInfoInitializer.InitializeSector(_mapTilesInfo, _sectorInfo);
            //------------------

            _unitsControllerMock = new UnitsControllerMock();
            _sectorController = new MapSectorController(_settingsList, _unitsControllerMock, _mapInfoStoreController);
            
            _mapViewController = new MapViewController();
            _mapViewController.Initialize(_sectorController);

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
            
        }

        private void TileClickHandler(IntVector2 position)
        {
            _unitsControllerMock.UpdatePosition(position);
            _mapViewController.UpdateTiles();
            _mapViewController.SetVisibleTiles(position);
        }
    }
}