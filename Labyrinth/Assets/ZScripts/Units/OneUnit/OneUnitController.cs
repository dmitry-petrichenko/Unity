using System;
using System.Collections.Generic;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class OneUnitController : IOneUnitController
    {
        public IOneUnitGraphicsController GraphicsController { get; set; }

        private MoveController _moveController;
        private AttackController _attackController;
        private IPathFinderController _pathFinderController;
        private IntVector2 _position;
        
        public event Action PositionChanged;

        public OneUnitController(
            MoveController moveController, 
            AttackController attackController,
            IPathFinderController pathFinderController)
        {
            _moveController = moveController;
            _attackController = attackController;
            _pathFinderController = pathFinderController;
        }

        public void Initialize(IOneUnitGraphicsController GraphicsController)
        {
            this.GraphicsController = GraphicsController;
            _position = GraphicsController.Position;

            _moveController.Initialize(this);
            _attackController.Initialize(this);
        }

        public void MoveTo(IntVector2 position)
        {
            List<IntVector2> path;
            path = _pathFinderController.GetPath(_position, position);
            _moveController.MoveTo(path);
        }

        public IntVector2 Position
        {
            get { return _position; }
            set
            {
                if (PositionChanged != null)
                    PositionChanged();
                
                _position = value;
            }
        }

    }
}