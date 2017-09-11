﻿namespace Labyrinth.Map
{
    public interface ITileView
    {
        IntVector2 ViewPosition { get; set; }
        int Type { get; set; }
        bool IsEmpty();
    }
}