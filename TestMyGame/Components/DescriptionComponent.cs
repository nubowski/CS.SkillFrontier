using CoreLibs.Components;

namespace TestMyGame.Components;

public class DescriptionComponent : IComponent
{
    public DescriptionComponent(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
}