using CoreLibs.Components;

namespace TestMyGame.Components;

public class GenderComponent : IComponent
{
    public enum GenderType
    {
        Male,
        Female
    }
    public GenderType Gender { get; set; }
}