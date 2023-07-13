using CoreLibs.Core;

namespace TestMyGame.Components.Stimul;

public class ToughnessAttributeComponent : IComponent
{
    public int Toughness { get; set; }

    public ToughnessAttributeComponent()
    {
        Toughness = 1;
    }
}