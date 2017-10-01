namespace Labyrinth.Additional.Tests.Modes
{
    public class SelectStartMode : IMode
    {
        private MapViewController _mapViewController;
        private IntVector2 _startPoint;

        public IntVector2 Point
        {
            get { return _startPoint; }
        }

        public void Initilize(MapViewController mapViewController)
        {
            _mapViewController = mapViewController;
            _startPoint = new IntVector2(2, 2);
            _mapViewController.InitializeStart(_startPoint);
        }
        
        public void LeftClick(IntVector2 position)
        {
            _startPoint = position;
            _mapViewController.InitializeStart(position);
        }

        public void RightClick(IntVector2 position)
        {
            
        }
    }
}