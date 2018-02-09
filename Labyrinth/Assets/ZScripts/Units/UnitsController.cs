using Zenject;
using ZScripts.Units.Enemy;

namespace ZScripts.Units
{
    public class UnitsController
    {
        private EnemyController _enemy;
        private EnemyController _enemy2;
        
        public UnitsController()
        {
            
        }

        [Inject]
        void Init(DiContainer container)
        {
            _enemy = container.Resolve<EnemyController>();
            _enemy.SetOnPosition(new IntVector2(3, 5));
            _enemy.MoveTo(new IntVector2(1,1));
            //_enemy.Animate();
            
            EnemyController _enemy4 = container.Resolve<EnemyController>();
            _enemy4.SetOnPosition(new IntVector2(0, 5));
            _enemy4.MoveTo(new IntVector2(0,1));
            //_enemy4.Animate();
            /*
            EnemyController _enemy3 = container.Resolve<EnemyController>();
            _enemy3.SetOnPosition(new IntVector2(4, 2));
            _enemy3.Animate();
            
            _enemy2 = container.Resolve<EnemyController>();
            _enemy2.SetOnPosition(new IntVector2(2, 2));
            _enemy2.Animate();
            */
        }
    }
}