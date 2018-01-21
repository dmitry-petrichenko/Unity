﻿using System;
using UnityEngine;

namespace ZScripts.Units
{
    public interface IOneUnitMotionController
    {
        void MoveToPosition(IntVector2 position);
        void Wait();
        IntVector2 Position { get; }
        void Initialize(GameObject unit);

        event Action CompleteMove;
    }
}