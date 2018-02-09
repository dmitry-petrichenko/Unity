using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZScripts.Units.UnitActions
{
    public class MoveToPositionAction : IUnitAction
    {
        private static int i = 0;
        private IOneUnitController _oneUnitController;
        private IntVector2 startPoint = new IntVector2(0, 0);
        private IntVector2 endPoint = new IntVector2(7, 7);

        private List<IntVector2> _vacantPoints;
        
        public MoveToPositionAction()
        {
            _vacantPoints = new List<IntVector2>();
            
            for (int i = startPoint.x; i < endPoint.x; i++)
            {
                for (int j = startPoint.y; j < endPoint.y; j++)
                {
                    _vacantPoints.Add(new IntVector2(i, j));
                }
            }
        }

        private List<IntVector2> GenerateVacantPointsWithout(IntVector2 index)
        {
            List<IntVector2> newPoints = new List<IntVector2>();
            
            foreach (var intVector2 in _vacantPoints)
            {
                if (intVector2.x != index.x)
                {
                    newPoints.Add(intVector2);
                }
            }

            return newPoints;
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
            if (point.x == _oneUnitController.Position.x &&
                point.y == _oneUnitController.Position.y)
            {
                point = GenerateVacantPoint(GenerateVacantPointsWithout(point));
            }
            if(i == 0)
            {
                i++;
                return new IntVector2(0, 0);//point;
            }
            else
            {
                return point;
            }

        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
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

