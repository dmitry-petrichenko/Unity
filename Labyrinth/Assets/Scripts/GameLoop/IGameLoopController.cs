using System;

namespace Labyrinth.GameLoop
{
    public interface IGameLoopController
    {
        event Action Updated;
    }
}