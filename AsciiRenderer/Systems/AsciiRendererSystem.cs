using AsciiRenderer.Components;
using AsciiRenderer.Interfaces;
using CoreLibs.Components;

namespace AsciiRenderer.Systems;

public class AsciiRendererSystem
{
    private readonly IComponentRegistry _componentRegistry;
    private readonly IAsciiRenderer _asciiRenderer;

    public AsciiRendererSystem(IComponentRegistry componentRegistry, IAsciiRenderer asciiRenderer)
    {
        _componentRegistry = componentRegistry;
        _asciiRenderer = asciiRenderer;
    }

    public void Draw()
    {
        var renderableEntities = _componentRegistry.GetEntitiesWithComponent<RenderableComponent>();
        _asciiRenderer.Clear();
        foreach (var entity in renderableEntities)
        {
            var renderableComponent = entity.GetComponent<RenderableComponent>();
            _asciiRenderer.Draw(renderableComponent.Character, renderableComponent.X, renderableComponent.Y);
        }
    }
}