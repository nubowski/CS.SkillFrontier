using CoreLibs.Components;

namespace TestMyGame.Components;

public class LocationActionComponent : IComponent
{
    public enum LocationAction
    {
        Grind,
        Stop,
        Explore,
        Idle
    }

    public LocationAction Action { get; set; }
}