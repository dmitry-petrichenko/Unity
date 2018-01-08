﻿using System;
using UnityEngine;

namespace ZScripts.Units.Rotation
{
    public class OneUnitRotationController : IOneUnitRotationController
    {
        private GameObject _unit;
        
        public void Initialize(GameObject unit)
        {
            _unit = unit.transform.Find("Unit").gameObject;
        }
        
        public double GetRotation(IntVector2 point1, IntVector2 point2)
        {
            double radians = Math.Atan2(point2.x - point1.x, point2.y - point1.y);
            double angle = radians / Math.PI * 180;
            return angle;
        }

        public void Rotate(IntVector2 point1, IntVector2 point2)
        {
            Debug.Log(point1.x + " " + point1.y + " " + point2.x + " " + point2.y);
            
            double angle = GetRotation(point1, point2);
            _unit.transform.localEulerAngles = new Vector3(0f, (float)angle, 0f);
            
        }
    }
}