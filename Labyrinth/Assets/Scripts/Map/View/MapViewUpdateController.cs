using System.Collections.Generic;
using Labyrinth;
using NSGraphics;

namespace Map
{
    public class MapViewUpdateController
    {
        private IGraphicsController _graphicsController;
        private List<IntVector2> _initializedIndexes;

        public void Initialize()
        {
            _graphicsController = ServiceLocator.GetGraphicsController();
            _initializedIndexes = new List<IntVector2>();
        }

        public void InitializeTiles(List<IMapTileInfo> tileInfos)
        {
            _initializedIndexes = new List<IntVector2>();

            foreach (ITileView tileInfo in tileInfos)
            {
                InitializeTile(tileInfo);
            }
        }

        private void InitializeTile(ITileView tileInfo)
        {
            if (_initializedIndexes.Contains(tileInfo.ViewPosition))
                return;

            switch (tileInfo.Type)
            {
                case MapTileType.Cube:
                {
                    _graphicsController.InitializeCube(tileInfo.ViewPosition);
                    break;
                }
                case MapTileType.Plane:
                {
                    _graphicsController.InitializePlane(tileInfo.ViewPosition);
                    break;
                }
                case MapTileType.Square:
                {
                    _graphicsController.InitializeSquare(tileInfo.ViewPosition);
                    break;
                }
                case MapTileType.Empty:
                {
                    _graphicsController.InitializeEmpty(tileInfo.ViewPosition);
                    break;
                }
            }
            
            _initializedIndexes.Add(tileInfo.ViewPosition);
        }

        public void DestroyTiles(List<IMapTileInfo> tileInfos)
        {
            foreach (ITileView tileInfo in tileInfos)
            {
                _graphicsController.DestroyTile(tileInfo.ViewPosition);
            }
        }
    }
}