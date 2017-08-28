using System.Collections.Generic;

namespace Labyrinth.Units
{
    public interface IPathFinderController
    {
        List<IntVector2> GetPath(IntVector2 point, IntVector2 point2);
    }
}