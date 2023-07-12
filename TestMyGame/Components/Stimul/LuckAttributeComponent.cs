using CoreLibs.Components;

namespace TestMyGame.Components.Stimul;

public class LuckAttributeComponent : IComponent
{
    public int Luck { get; set; }

    public LuckAttributeComponent()
    {
        Luck = 1;
    }
}