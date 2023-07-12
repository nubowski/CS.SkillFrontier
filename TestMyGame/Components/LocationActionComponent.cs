using CoreLibs.Components;

namespace TestMyGame.Components;

public class LocationActionComponent : IComponent
{
    public enum LocationAction
    {
        Grind,
        Stop,
        Explore
    }

    public LocationAction Action { get; set; }
}