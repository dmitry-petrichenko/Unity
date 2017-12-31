using System;

namespace ZScripts.GameLoop
{
    public interface IGameLoopController
    {
        event Action Updated;
    }
}