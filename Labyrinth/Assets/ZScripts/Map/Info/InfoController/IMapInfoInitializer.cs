namespace ZScripts.Map.Info
 {
     public interface IMapInfoInitializer
     {
         void InitializeSector(IMapTileInfo[,] mapTilesInfo);
         void CreateSector(IntVector2 startPoint, IntVector2 size);
         void InitializeCube(IntVector2 position);
         void InitializePlane(IntVector2 position);
         IMapTileInfo CreateEmptyTileInfo(IntVector2 position);
         IMapTileInfo[,] MapTilesInfo { get; }
     }
 }