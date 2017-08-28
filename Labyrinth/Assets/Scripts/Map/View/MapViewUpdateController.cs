using System.Collections.Generic;

namespace Labyrinth.Map
{
    public class MapViewUpdateController
    {
        private IMapGraphicsController _graphicsController;
        private List<IntVector2> _initializedIndexes;

        public void Initialize()
        {
            _graphicsController = ServiceLocator.GetGraphicsController();
            _initializedIndexes = new List<IntVector2>();
        }

        public void InitializeTiles<T>(List<T> tileInfos) where T : ITileView
        {
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

            _initializedIndexes.Add(new IntVector2(tileInfo.ViewPosition.x, tileInfo.ViewPosition.y));
        }

        public void DestroyTiles<T>(List<T> tileInfos) where T : ITileView
        {
            foreach (ITileView tileInfo in tileInfos)
            {
                _graphicsController.DestroyTile(tileInfo.ViewPosition);
                _initializedIndexes.Remove(tileInfo.ViewPosition);
            }
        }
    }
}