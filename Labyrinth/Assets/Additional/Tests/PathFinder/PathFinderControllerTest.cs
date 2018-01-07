using System;
using System.Collections.Generic;
using Units.PathFinder;

namespace Labyrinth.Additional.Tests
{
    
    public class PathFinderControllerTest : PathFinderController
    {
        private MapViewController _mapViewController;

        public PathFinderControllerTest(MapViewController mapViewController)
        {
            _mapViewController = mapViewController;
        }

        public void GetPathDrawingStepMode(IntVector2 point, IntVector2 point2, Boolean testMode = false)
        {
            GetPath(point, point2, true);
            DrawTemp(tempTestData);
        }
        
        public void GetPathDrawingFullMode(IntVector2 point, IntVector2 point2, Boolean testMode = false)
        {
            List<IntVector2> path = GetPath(point, point2);
            DrawPath(path);
        }
        
        public void DrawTemp(TempData tempFinderData)
        {
            foreach (Vertex2D vertex2D in tempFinderData.OpenList)
            {
                _mapViewController.InitializeOpen(vertex2D.Index);
            }
            
            foreach (IntVector2 intVector2 in tempFinderData.CloseList)
            {
                _mapViewController.InitializeCloseList(intVector2);
            }
            _mapViewController.InitializMinor(tempFinderData.CurrentVertex.Index);
        }
        
        public void DrawPath(List<IntVector2> path)
        {
            foreach (IntVector2 intVector2 in path)
            {
                DrawWayCell(intVector2);
            }
        }
        
        public void DrawWayCell(IntVector2 cell)
        {
            _mapViewController.InitializeWay(cell);
        }
    }
    

}