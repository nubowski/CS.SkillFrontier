using CoreLibs.Components;

namespace AsciiRenderer.Components;

public class RenderableComponent : IComponent
{
    public char Character { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}