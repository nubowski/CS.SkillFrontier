using AsciiRenderer.Components;
using AsciiRenderer.Interfaces;
using CoreLibs.Entities;
using CoreLibs.Systems;

namespace AsciiRenderer.Systems;

public class AsciiRendererSystem : BaseSystem
{
    private readonly IAsciiRenderer _asciiRenderer;

    public AsciiRendererSystem(EntityManager entityManager, IAsciiRenderer asciiRenderer) 
        : base(entityManager)
    {
        _asciiRenderer = asciiRenderer;
        ComponentFilter.MustHaveComponents.Add(typeof(RenderableComponent));
    }

    public override void Update(float deltaTime)
    {
        _asciiRenderer.Clear();
        base.Update(deltaTime);
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        var renderableComponent = entity.GetComponent<RenderableComponent>();
        _asciiRenderer.Draw(renderableComponent.Character, renderableComponent.X, renderableComponent.Y);
    }
}