using System;
using UnityEngine;

namespace ZScripts.Units.Rotation
{
    public class OneUnitRotationController : IOneUnitRotationController
    {
        private GameObject _unit;
        private double _rotation = 0.0;
        
        public void Initialize(GameObject unit)
        {
            _unit = unit.transform.Find("Unit").gameObject;
        }
        
        public double GetRotation(IntVector2 point1, IntVector2 point2)
        {
            Debug.Log("Transform " + (point2.x - point1.x) + " " + (point2.y - point1.y));
            double radians = Math.Atan2(point2.x - point1.x, point2.y - point1.y);
            double angle = radians / Math.PI * 180;
            
                //var radians:Number = Math.atan2(y2 - y1, x2 - x1);
                //var angle:Number = (radians / Math.PI) * 180;
			/*
                if (Math.abs(_rotation) > 90 && Math.abs(angle) > 90)
                    if (!(_rotation + angle < -180) && !(_rotation + angle > 180))
                        if (angle < 0)
                            angle += 360;
                        else
                            angle -= 360;
						
                return angle;*/
            return angle;
        }

        public void Rotate(IntVector2 point1, IntVector2 point2)
        {
            Debug.Log(point1.x + " " + point1.y + " " + point2.x + " " + point2.y);
            
            double angle = GetRotation(point1, point2);
            _rotation = angle;
            _unit.transform.localEulerAngles = new Vector3(0f, (float)_rotation, 0f);
            //_unit.transform.Rotate(0f, (float)_rotation, 0f); 
            
        }
    }
}