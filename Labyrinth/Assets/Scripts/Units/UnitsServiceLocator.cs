namespace Labyrinth.Units
{
    public static class UnitsServiceLocator
    {
        private static IPathFinderController _pathFinder;

        public static void InitializePathFinder(IPathFinderController pathFinder)
        {
            _pathFinder = pathFinder;
        }

        public static IPathFinderController GetPathFinder()
        {
            return _pathFinder;
        }
    }
}