#if !NOT_UNITY3D

using ModestTree;
using UnityEngine;

namespace Zenject
{
    public class PrefabProvider : IPrefabProvider
    {
        readonly Object _prefab;

        public PrefabProvider(Object prefab)
        {
            Assert.IsNotNull(prefab);
            _prefab = prefab;
        }

        public Object GetPrefab()
        {
            return _prefab;
        }
    }
}

#endif


