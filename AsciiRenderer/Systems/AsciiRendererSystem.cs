using AsciiRenderer.Components;
using AsciiRenderer.Interfaces;
using CoreLibs.Components;
using CoreLibs.Systems;

namespace AsciiRenderer.Systems;

public class AsciiRendererSystem : BaseSystem
{
    private readonly IComponentRegistry _componentRegistry;
    private readonly IAsciiRenderer _asciiRenderer;

    public AsciiRendererSystem(IComponentRegistry componentRegistry, IAsciiRenderer asciiRenderer)
    {
        _componentRegistry = componentRegistry;
        _asciiRenderer = asciiRenderer;
        ComponentFilter.MustHaveComponents.Add(typeof(RenderableComponent));
    }

    public override int Order => 3; // Set the order based on your needs

    public override void Update(float deltaTime)
    {
        var renderableEntities = _componentRegistry.GetEntitiesWithComponents(ComponentFilter);
        _asciiRenderer.Clear();
        foreach (var entity in renderableEntities)
        {
            var renderableComponent = entity.GetComponent<RenderableComponent>();
            _asciiRenderer.Draw(renderableComponent.Character, renderableComponent.X, renderableComponent.Y);
        }
    }
}