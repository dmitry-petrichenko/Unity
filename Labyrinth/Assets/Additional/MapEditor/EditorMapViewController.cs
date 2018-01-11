using System.Collections.Generic;
using ZScripts;
using ZScripts.Map.Info;
using ZScripts.Map.View;

namespace Additional
{
    public class EditorMapViewController
    {
        private IMapViewController _mapViewController;
        private List<IntVector2> _initializedIndexes;
        private IMapTileInfo[,] _tileInfos;

        public void Initialize()
        {
            _mapViewController = MapServiceLocator.GetMapViewController();
        }

        public void InitializeTiles(IMapTileInfo[,] tileInfos)
        {
            _tileInfos = tileInfos;
            int lengthX = tileInfos.GetLength(0);
            int lengthY = tileInfos.GetLength(1);

            for (int i = 0; i < lengthX; i += 2)
            {
                for (int j = 0; j < lengthY; j += 2)
                {
                    InitializeTile(tileInfos[i, j]);
                }
            }
        }

        public void UpdateTile(IntVector2 position)
        {
            InitializeTile(_tileInfos[position.x, position.y]);
        }

        private void InitializeTile(IMapTileInfo tileInfo)
        {
            IntVector2 position = new IntVector2(tileInfo.Index.x / 2, tileInfo.Index.y / 2);
            switch (tileInfo.Type)
            {
                case MapTileType.Cube:
                {
                    _mapViewController.InitializeCube(position);
                    break;
                }
                case MapTileType.Square:
                {
                    _mapViewController.InitializeSquare(position);
                    break;
                }
                case MapTileType.Empty:
                {
                    _mapViewController.InitializeEmpty(position);
                    break;
                }
            }
        }
    }
}