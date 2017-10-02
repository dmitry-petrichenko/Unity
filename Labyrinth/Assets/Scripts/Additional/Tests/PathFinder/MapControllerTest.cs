using System;
using System.Collections.Generic;
using Labyrinth.Additional.Tests.Modes;
using Labyrinth.Map;
using Labyrinth.Units;
using Units.PathFinder;

namespace Labyrinth.Additional.Tests
{
    public class MapControllerTest
    {
        private IMapInfoController _mapInfoController;
        private MapViewController _mapViewController;
        private IMode _mode;
        private bool _modeType;
        private SelectStartMode _startMode;
        private SelectEndMode _endMode;
        private PathFinderControllerTest _pathFinderController;
        private TempData temp;

        public MapControllerTest()
        {
            
        }
        
        public void Initialize(IMapInfoController mapInfoController, MapViewController mapViewController)
        {
            _mapInfoController = mapInfoController;
            _mapViewController = mapViewController;
            IntVector2 _intVector2;

            _mapViewController.TileClicked += LeftClicked;
            _mapViewController.TileClicked += RightClicked;

                
            for (int i = 0; i < _mapInfoController.MapInfoCommon.MapWidth; i++)
            {
                for (int j = 0; j < _mapInfoController.MapInfoCommon.MapHeight; j++)
                {
                    _intVector2.x = i;
                    _intVector2.y = j;
                    InitializeTile(_mapInfoController.GetMapTileInfo(_intVector2).Type, _intVector2);
                }
            }
            
            _startMode = new SelectStartMode();
            _startMode.Initilize(_mapViewController);
            
            _endMode = new SelectEndMode();
            _endMode.Initilize(_mapViewController);
            _mode = _endMode;
        }
        
        private void LeftClicked(IntVector2 position)
        {
            InitializeTile(_mapInfoController.GetMapTileInfo(_mode.Point).Type, _mode.Point);
            _mode.LeftClick(position);
        }
        
        private void RightClicked(IntVector2 position)
        {
            _mode.RightClick(position);
        }

        private void InitializeTile(int type, IntVector2 position)
        {
            switch (type)
            {
                case MapTileType.Square:
                {
                    _mapViewController.InitializeEmpty(position);
                    break;
                    
                }
                default:
                {
                    _mapViewController.InitializeBusy(position);
                    break;
                }
            }
        }

        public void SetPath()
        {
            Boolean stepMode = false;

            
            _pathFinderController = UnitsServiceLocator.GetPathFinder() as PathFinderControllerTest;
            
            if (stepMode)
            {
                _pathFinderController.GetPathDrawingStepMode(_startMode.Point, _endMode.Point);
            }
            else
            {
                _pathFinderController.GetPathDrawingFullMode(_startMode.Point, _endMode.Point);
            }
        }
        
       
        public void ChangeMode()
        {
            _modeType = !_modeType;
            if (_modeType)
            {
                 _mode = _endMode;
            }
               
            else
            {
                _mode = _startMode;
            }
        }
    }
}