using NSGraphics;
using NSMapInfoController;
using NSMapViewController;

public static class ServiceLocator
{
     private static IMapInfoController _mapInfoController;
     private static IMapViewController _mapViewController;
     private static IGraphicsController _graphicsController;
     
     public static void InitializeGraphicsController(IGraphicsController controller)
     {
          _graphicsController = controller;
     }
     
     public static IGraphicsController GetGraphicsController()
     {
          return _graphicsController;
     }
     
     public static void InitializeMapInfoController(IMapInfoController controller)
     {
          _mapInfoController = controller;
     }
     
     public static IMapInfoController GetMapInfoController()
     {
          return _mapInfoController;
     }
     
     public static void InitializeMapViewController(IMapViewController controller)
     {
          _mapViewController = controller;
     }
     
     public static IMapViewController GetMapViewController()
     {
          return _mapViewController;
     }
}