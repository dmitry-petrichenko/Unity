using System.Globalization;
using System.IO;
using LitJson;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace ZScripts.Units.Settings
{
    public class UnitSettings : IUnitSettings
    {
        public float MotionSpeed { get; private set; }
        public GameObject GraphicObject { get; private set; }
        public float RotationSpeed { get; private set; }

        public static string UNITS_ASSETS_PATH = "Units/Resources/";

        private string _prefabPath;
        private string _jsonString;
        private JsonData _infoJson;
        private DiContainer _container;

        public UnitSettings(DiContainer container)
        {
            _container = container;
        }

        public void Initialize(string settingsPath)
        {
            _jsonString = File.ReadAllText(settingsPath);
            _infoJson = JsonMapper.ToObject(_jsonString);
            
            MotionSpeed = float.Parse((string)_infoJson["MotionSpeed"], CultureInfo.InvariantCulture.NumberFormat);
            _prefabPath = (string) _infoJson["PrefabPath"];
            RotationSpeed = float.Parse((string)_infoJson["RotationSpeed"], CultureInfo.InvariantCulture.NumberFormat);
 
            GraphicObject = _container.InstantiatePrefabResource(_prefabPath);
        }

    }
}