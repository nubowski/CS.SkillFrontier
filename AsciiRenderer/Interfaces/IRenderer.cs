using CoreLibs.Entities;

namespace AsciiRenderer.Interfaces;

public interface IRenderer
{
    void Render(Entity entity);
}