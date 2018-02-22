using Zenject;
using ZScripts.Units.Enemy;
using ZScripts.Units.Player;

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
        void Init(DiContainer container, IPlayerController player)
        {/*
            _enemy = container.Resolve<EnemyController>();
            _enemy.SetOnPosition(new IntVector2(3, 6));
            //_enemy.MoveTo(new IntVector2(3, 3));
            _enemy.Attack(player);
            //_enemy.Animate();
            /*
            EnemyController _enemy4 = container.Resolve<EnemyController>();
            _enemy4.SetOnPosition(new IntVector2(0, 0));
            //_enemy4.MoveTo(new IntVector2(0, 3));
            _enemy4.Animate();
            
            EnemyController _enemy3 = container.Resolve<EnemyController>();
            _enemy3.SetOnPosition(new IntVector2(4, 2));
            _enemy3.Animate();
            
            _enemy2 = container.Resolve<EnemyController>();
            _enemy2.SetOnPosition(new IntVector2(2, 2));
            _enemy2.Animate();
            
            EnemyController _enemy5 = container.Resolve<EnemyController>();
            _enemy5.SetOnPosition(new IntVector2(3, 0));
            _enemy5.Animate();
            
            EnemyController _enemy6 = container.Resolve<EnemyController>();
            _enemy6.SetOnPosition(new IntVector2(4, 0));
            _enemy6.Animate();
            
            EnemyController _enemy7 = container.Resolve<EnemyController>();
            _enemy7.SetOnPosition(new IntVector2(5, 0));
            _enemy7.Animate();
            */
        }
    }
}