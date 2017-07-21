using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState, Unique]
public class ScoreComponent : IComponent
{
    public int value;
}