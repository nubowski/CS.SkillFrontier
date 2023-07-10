using CoreLibs.Components;

namespace TestMyGame.Components;

public class MoveCommandComponent : IComponent
{
    public int Dx { get; set; }
    public int Dy { get; set; }
}