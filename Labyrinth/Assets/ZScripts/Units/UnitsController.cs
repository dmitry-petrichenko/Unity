using Zenject;
using ZScripts.Units.Enemy;

namespace ZScripts.Units
{
    public class UnitsController
    {
        private EnemyController _enemy;
        
        public UnitsController()
        {
            
        }

        [Inject]
        void Init(DiContainer container)
        {
            _enemy = container.Resolve<EnemyController>();
            _enemy.SetOnPosition(new IntVector2(3, 3));
            _enemy.Animate();
        }
    }
}