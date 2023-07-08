using CoreLibs.Components;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class DamageSystem : ISystem
{
    private readonly IComponentRegistry _componentRegistry;


    public DamageSystem(IComponentRegistry componentRegistry)
    {
        _componentRegistry = componentRegistry;
    }

    public int Order { get; }

    public void Update(float deltaTime)
    {
        var entitiesWithDamage = _componentRegistry.GetEntitiesWithComponent<DamageComponent>();

        foreach (var entity in entitiesWithDamage)
        {
            var damage = entity.GetComponent<DamageComponent>();
            var health = entity.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.CurrentHealth -= damage.Damage;
                Console.WriteLine($"Entity {entity.Id} took {damage.Damage} damage. Current health: {health.CurrentHealth}");
            }
        }
    }
}