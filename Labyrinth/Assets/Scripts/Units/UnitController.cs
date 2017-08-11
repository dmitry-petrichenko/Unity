using Labyrinth;
using UnityEngine;

namespace Units
{
    public class UnitController : IUnitController
    {
        public IUnitGraphicsController GraphicsController { get; set; }

        private MoveController _moveController;
        private AttackController _attackController;

        public UnitController()
        {
            
        }

        public void Initialize(IUnitGraphicsController GraphicsController)
        {
            this.GraphicsController = GraphicsController; 
            
            _moveController = new MoveController();
            _moveController.Initialize(this);
            
            _attackController = new AttackController();
            _attackController.Initialize(this);
        }
        
        public void MoveTo(IntVector2 position)
        {
            _moveController.MoveTo(position);
        }
    }
}