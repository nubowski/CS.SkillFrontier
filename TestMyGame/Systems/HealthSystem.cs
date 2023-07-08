using CoreLibs.Components;
using CoreLibs.Entities;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class HealthSystem : ISystem
{
    private readonly IComponentRegistry _componentRegistry;

    public HealthSystem(IComponentRegistry componentRegistry)
    {
        _componentRegistry = componentRegistry;
    }

    public void Update(float deltaTime)
    {
        var entitiesWithHealth = _componentRegistry.GetEntitiesWithComponent<HealthComponent>();
        
        foreach (var entity in entitiesWithHealth)
        {
            var health = entity.GetComponent<HealthComponent>();
            if (health.CurrentHealth <= 0)
            {
                
                Console.WriteLine($"Entity {entity.Id} has died.");
            }
        }
    }
}