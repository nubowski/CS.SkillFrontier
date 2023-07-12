using CoreLibs.Components;

namespace TestMyGame.Components;

public class RaceComponent : IComponent
{
    public enum RaceType
    {
        Human,
        Orc,
        Beast
    }

    public RaceType Race { get; set; }
}