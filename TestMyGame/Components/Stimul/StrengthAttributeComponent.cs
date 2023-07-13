using CoreLibs.Core;

namespace TestMyGame.Components.Stimul;

public class StrengthAttributeComponent : IComponent
{
    public int Strength { get; set; }

    public StrengthAttributeComponent()
    {
        Strength = 1;
    }
}