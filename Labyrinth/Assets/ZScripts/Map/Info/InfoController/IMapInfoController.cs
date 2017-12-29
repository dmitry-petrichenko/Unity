namespace ZScripts.Map.Info
{
    public interface IMapInfoController
    {
        IMapTileInfo GetMapTileInfo(IntVector2 position);
        void UpdateMapTileInfo(IMapTileInfo mapTileInfo);
        IMapInfoCommon MapInfoCommon { get; }
    }
}