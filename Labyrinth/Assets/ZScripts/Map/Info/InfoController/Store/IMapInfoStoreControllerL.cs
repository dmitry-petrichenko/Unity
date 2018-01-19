namespace ZScripts.Map.Info
{
    public interface IMapInfoStoreControllerL
    {
        IMapTileInfo[,] UploadSector(IntVector2 dirrection);
    }
}