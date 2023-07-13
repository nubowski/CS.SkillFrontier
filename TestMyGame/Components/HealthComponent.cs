using CoreLibs;

namespace TestMyGame.Components;

public class HealthComponent : IComponent
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
}