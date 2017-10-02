using System;
using System.Collections.Generic;
using Labyrinth.Additional.Tests;
using UnityEngine.VR.WSA.Persistence;

namespace Labyrinth.Units
{
    public interface IPathFinderController
    {
        List<IntVector2> GetPath(IntVector2 point, IntVector2 point2, Boolean testMode);
    }
}