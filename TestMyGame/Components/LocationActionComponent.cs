using CoreLibs.Components;

namespace TestMyGame.Components;

public class LocationActionComponent : IComponent
{
    public enum LocationAction
    {
        Idle,
        Grind,
        Stop,
        Explore
    }

    public LocationAction Action { get; set; }
}