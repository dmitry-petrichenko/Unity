using System.Collections.Generic;

namespace ZScripts.Units.PathFinder
{
    public interface IPathFinderController
    {
        List<IntVector2> GetPath(IntVector2 point, IntVector2 point2, Dictionary<IntVector2, bool> occupiedPossitions);
    }
}