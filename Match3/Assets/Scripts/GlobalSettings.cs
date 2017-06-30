using UnityEngine;

[CreateAssetMenu]
public class GlobalSettings : ScriptableObject
{
     public int height = 5;
     public int width = 5;

     public int widthSpacing;
     public int heightSpacing;

     public GameObject backgroundSquarePrefab;
     public GameObject tileViewPrefab;
}