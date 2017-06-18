using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    public GameObject hexagonPrefab;

    public float widthSpacing;
    public float heightSpacing;
    public float heightOffset;

    public Color evenColor;
    public Color oddColor;

    public float clickRadius = 30f;
}

