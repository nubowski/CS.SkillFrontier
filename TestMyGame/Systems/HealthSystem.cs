using CoreLibs.Components;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class HealthSystem : ISystem
{
    private readonly IComponentRegistry _componentRegistry;
    private EventManager _eventManager;
    private EntityManager _entityManager;

    public HealthSystem(IComponentRegistry componentRegistry, EventManager eventManager, EntityManager entityManager)
    {
        _componentRegistry = componentRegistry;
        _eventManager = eventManager;
        _entityManager = entityManager;
    }

    public int Order => 2;

    public void Update(float deltaTime)
    {
        var entitiesWithHealth = _componentRegistry.GetEntitiesWithComponent<HealthComponent>();
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