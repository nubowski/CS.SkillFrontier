using CoreLibs.Components;

namespace TestMyGame.Components;

public class HealthComponent : IComponent
{
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
}