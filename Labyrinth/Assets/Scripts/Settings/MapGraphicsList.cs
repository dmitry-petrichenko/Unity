using UnityEngine;

namespace Labyrinth.Settings
{
    public class MapGraphicsList
    {
        public GameObject MainScene { get; private set; }
        public GameObject Plane { get; private set; }
        public GameObject Cube { get; private set; }
        public GameObject Empty { get; private set; }
        public GameObject Square { get; private set; }

        public void Initialize(GameObject mainScene, GameObject plane, GameObject cube, GameObject square,
            GameObject empty)
        {
            MainScene = mainScene;
            Plane = plane;
            Cube = cube;
            Empty = empty;
            Square = square;
        }

    }
}