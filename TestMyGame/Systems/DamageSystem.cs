using CoreLibs.Components;
using CoreLibs.Events;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class DamageSystem : ISystem
{
    private readonly IComponentRegistry _componentRegistry;
    private EventManager _eventManager;


    public DamageSystem(IComponentRegistry componentRegistry, EventManager eventManager)
    {
        _componentRegistry = componentRegistry;
        _eventManager = eventManager;
    }

    public int Order => 1;

    public void Update(float deltaTime)
    {
        var entitiesWithDamage = _componentRegistry.GetEntitiesWithComponent<DamageComponent>();
        var entitiesWithHealth = _componentRegistry.GetEntitiesWithComponent<HealthComponent>();
            
        foreach (var attacker in entitiesWithDamage)
        {
            var damageComponent = attacker.GetComponent<DamageComponent>();
                
            foreach (var defender in entitiesWithHealth)
            {
                if (defender == attacker) continue; // Skip self

                var healthComponent = defender.GetComponent<HealthComponent>();
                healthComponent.CurrentHealth -= damageComponent.Damage;
                    
                Console.WriteLine($"Entity {attacker.Id} attacked entity {defender.Id} for {damageComponent.Damage} damage. Defender health: {healthComponent.CurrentHealth}");
                
            }
        }
    }
}