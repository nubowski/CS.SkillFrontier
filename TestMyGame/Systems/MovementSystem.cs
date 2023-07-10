using AsciiRenderer.Components;
using CoreLibs.Components;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class MovementSystem : BaseSystem
{
    private readonly IComponentRegistry _componentRegistry;

    public MovementSystem(IComponentRegistry componentRegistry)
    {
        _componentRegistry = componentRegistry;
        ComponentFilter.MustHaveComponents.AddRange(new Type[] { typeof(MoveCommandComponent), typeof(RenderableComponent) });
    }

    public override int Order => 0; // Change this based on your needs

    public override void Update(float deltaTime)
    {
        var entitiesToMove = _componentRegistry.GetEntitiesWithComponents(ComponentFilter);

        foreach (var entity in entitiesToMove)
        {
            var moveCommand = entity.GetComponent<MoveCommandComponent>();
            var renderable = entity.GetComponent<RenderableComponent>();

            renderable.X += (int)(moveCommand.Dx * deltaTime);
            renderable.Y += (int)(moveCommand.Dy * deltaTime);

            entity.RemoveComponent<MoveCommandComponent>();
        }
    }
}