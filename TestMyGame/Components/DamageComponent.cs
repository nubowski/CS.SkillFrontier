using CoreLibs.Components;

namespace TestMyGame.Components;

[Serializable]
public class DamageComponent : IComponent
{
    public int Damage { get; set; }
}