using System;
using System.Collections.Generic;
using UnityEngine;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units.UnitActions
{
    public class MoveToPositionAction : IUnitAction
    {
        private static int i = 0;
        private IOneUnitController _oneUnitController;
        private IntVector2 startPoint = new IntVector2(0, 0);
        private IntVector2 endPoint = new IntVector2(7, 7);
        private IGrid _grid;

        private List<IntVector2> _vacantPoints;
        
        public MoveToPositionAction(IGrid grid)
        {
            _vacantPoints = new List<IntVector2>();
            _grid = grid;
            
        }

        private void InitializeVacantPoints()
        {
            IntVector2 intVector2;
            
            for (int i = startPoint.x; i < endPoint.x; i++)
            {
                for (int j = startPoint.y; j < endPoint.y; j++)
                {
                    intVector2 = new IntVector2(i, j);
                    if (_grid.GetCell(intVector2))
                    {
                        if (intVector2.x == _oneUnitController.Position.x &&
                            intVector2.y == _oneUnitController.Position.y)
                        {
                            continue;
                        }
                        _vacantPoints.Add(intVector2);
                    }
                }
            }
        }


        private IntVector2 GenerateVacantPoint(List<IntVector2> points)
        {
            int index = UnityEngine.Random.Range(0, points.Count - 1);

            return points[index];
        }

        private IntVector2 GenerateRandomPoint()
        {
            IntVector2 point;

            point = GenerateVacantPoint(_vacantPoints);

            return point;
        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
            InitializeVacantPoints();
        }
        
        public void Start()
        {
            _oneUnitController.CompleteMoveTo += MoveCompleteHandler;
            IntVector2 position = GenerateRandomPoint();
            _oneUnitController.MoveTo(position);
        }

        private void MoveCompleteHandler()
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        }

        public void Stop()
        {
            
        }

        public void Destroy()
        {
            
        }

        public event Action OnComplete;
    }
}

