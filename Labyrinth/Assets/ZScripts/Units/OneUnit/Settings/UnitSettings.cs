using UnityEngine;

namespace ZScripts.Units.Settings
{
    public class UnitSettings : IUnitSettings
    {
        public float MotionSpeed { get; private set; }
        public GameObject GraphicObject { get; private set; }
        public enum UnitType {Player, Spider};
        
        
        public UnitSettings(UnitType unitType, GameObject graphicObject)
        {
            GraphicObject = graphicObject;
            switch (unitType)
            {
                case UnitType.Player:
                {
                    MotionSpeed = 0.7f;
                    break;
                }
                case UnitType.Spider:
                {
                    MotionSpeed = 1.8f;
                    break;
                }
            }
        }
    }
}