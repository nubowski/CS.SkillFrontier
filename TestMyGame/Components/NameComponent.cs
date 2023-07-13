using CoreLibs;

namespace TestMyGame.Components;

public class NameComponent : IComponent
{
    public NameComponent(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}