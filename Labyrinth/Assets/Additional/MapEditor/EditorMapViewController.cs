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
        private Dictionary<IntVector2, IMapTileInfo> _tileInfos = new Dictionary<IntVector2, IMapTileInfo>();

        public void Initialize()
        {
            _mapViewController = MapServiceLocator.GetMapViewController();
        }

        public void InitializeTiles(Dictionary<IntVector2, IMapTileInfo> tileInfos)
        {
            _tileInfos = tileInfos;

            foreach (var info in tileInfos) 
            {
                InitializeTile(info.Value);
            }
        }

        public void UpdateTile(IntVector2 position)
        {
            InitializeTile(_tileInfos[position]);
        }

        private void InitializeTile(IMapTileInfo tileInfo)
        {
            IntVector2 position = new IntVector2(tileInfo.Index.x / MainEditorController.SCALE, tileInfo.Index.y / MainEditorController.SCALE);
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