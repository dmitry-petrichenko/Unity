using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState, Unique]
public class GlobalSettingsComponent : IComponent
{
    public GlobalSettings value;
}