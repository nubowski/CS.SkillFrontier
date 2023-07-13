using CoreLibs.Core;

namespace TestMyGame.Components;

public class LocationComponent : IComponent
{
    public string Name { get; set; }
    public string Description { get; set; }

    public LocationComponent(string name, string description)
    {
        Name = name;
        Description = description;
    }
}