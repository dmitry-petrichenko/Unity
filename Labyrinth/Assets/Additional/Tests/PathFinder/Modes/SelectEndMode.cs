namespace Labyrinth.Additional.Tests.Modes
{
    public class SelectEndMode : IMode
    {
        private MapViewController _mapViewController;
        private IntVector2 _endPoint;

        public IntVector2 Point
        {
            get { return _endPoint; }
        }

        public void Initilize(MapViewController mapViewController)
        {
            _mapViewController = mapViewController;
            _endPoint = new IntVector2(3, 3);
            _mapViewController.InitializeEnd(_endPoint);
        }
        
        public void LeftClick(IntVector2 position)
        {
            _endPoint = position;
            _mapViewController.InitializeEnd(position);
        }

        public void RightClick(IntVector2 position)
        {
            
        }
    }
}