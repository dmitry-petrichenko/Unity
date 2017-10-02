using System.Collections.Generic;
using Labyrinth;
using Labyrinth.Units;

namespace Units
{
    public class UnitController : IUnitController
    {
        public IUnitGraphicsController GraphicsController { get; set; }

        private MoveController _moveController;
        private AttackController _attackController;
        private IPathFinderController _pathFinderController;
        private IntVector2 _position;

        public UnitController()
        {
        }

        public void Initialize(IUnitGraphicsController GraphicsController)
        {
            this.GraphicsController = GraphicsController;
            _position = GraphicsController.Position;

            _pathFinderController = UnitsServiceLocator.GetPathFinder();

            _moveController = new MoveController();
            _moveController.Initialize(this);

            _attackController = new AttackController();
            _attackController.Initialize(this);
        }

        public void MoveTo(IntVector2 position)
        {
            List<IntVector2> path;
            path = _pathFinderController.GetPath(_position, position, false);
            _moveController.MoveTo(path);
        }

        public IntVector2 Position
        {
            get { return GraphicsController.Position; }
            set { _position = value; }
        }
    }
}