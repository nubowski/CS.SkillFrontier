using CoreLibs.Components;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class HealthSystem : BaseSystem
{
    private readonly IComponentRegistry _componentRegistry;
    private EntityManager _entityManager;

    public HealthSystem(IComponentRegistry componentRegistry, EntityManager entityManager)
    {
        _componentRegistry = componentRegistry;
        _entityManager = entityManager;
        ComponentFilter.MustHaveComponents.Add(typeof(HealthComponent));
    }

    public override int Order => 2;

    public override void Update(float deltaTime)
    {
        var entitiesWithHealth = _componentRegistry.GetEntitiesWithComponents(ComponentFilter);
        var entitiesToRemove = new List<Entity>();

        foreach (var entity in entitiesWithHealth)
        {
            var health = entity.GetComponent<HealthComponent>();
            if (health.CurrentHealth <= 0)
            {
                entitiesToRemove.Add(entity);
                Console.WriteLine($"Entity {entity.Id} has died.");
            }
        }

        foreach (var entity in entitiesToRemove)
        {
            _entityManager.DestroyEntity(entity);
        }
    }
}