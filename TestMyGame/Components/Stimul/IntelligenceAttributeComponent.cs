using CoreLibs.Core;

namespace TestMyGame.Components.Stimul;

public class IntelligenceAttributeComponent : IComponent
{
    public int Intelligence { get; set; }

    public IntelligenceAttributeComponent()
    {
        Intelligence = 1;
    }
}