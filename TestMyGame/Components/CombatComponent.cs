using CoreLibs.Core;

namespace TestMyGame.Components;

public class CombatComponent : IComponent
{
    public Entity Target { get; set; }
    public bool IsTurn { get; set; }
}