using CoreLibs.Core;
using CoreLibs.Events;
using TestMyGame.Components;
using TestMyGame.Components.Stimul;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class HealthSystem : BaseSystem
{
    public HealthSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<DamageEvent>(HandleDamage);
        _eventManager.AddListener<HealingEvent>(HandleHealing);
        _eventManager.AddListener<StatsUpdatedEvent>(UpdateMaxHealth);
    }

    private void HandleDamage(DamageEvent damageEvent)
    {
        var healthComponent = damageEvent.TargetEntity.GetComponent<HealthComponent>();
        healthComponent.CurrentHealth -= damageEvent.DamageAmount;

        if (healthComponent.CurrentHealth <= 0)
        {
            _eventManager.Emit(new DeathEvent(damageEvent.TargetEntity));
        }
    }

    private void HandleHealing(HealingEvent healingEvent)
    {
        var healthComponent = healingEvent.TargetEntity.GetComponent<HealthComponent>();
        healthComponent.CurrentHealth += healingEvent.HealingAmount;

        if (healthComponent.CurrentHealth > healthComponent.MaxHealth)
        {
            healthComponent.CurrentHealth = healthComponent.MaxHealth;
        }
    }
    
    public void UpdateMaxHealth(StatsUpdatedEvent statsUpdatedEvent)
    {
        var strComponent = statsUpdatedEvent.TargetEntity.GetComponent<StrengthAttributeComponent>();
        var tghComponent = statsUpdatedEvent.TargetEntity.GetComponent<ToughnessAttributeComponent>();
        var healthComponent = statsUpdatedEvent.TargetEntity.GetComponent<HealthComponent>();

        // Recalculate MaxHealth based on Strength and Toughness
        healthComponent.MaxHealth = 10 * strComponent.Strength + 20 * tghComponent.Toughness;

        // If necessary, adjust current health to not exceed MaxHealth
        if (healthComponent.CurrentHealth > healthComponent.MaxHealth)
        {
            healthComponent.CurrentHealth = healthComponent.MaxHealth;
        }

        statsUpdatedEvent.TargetEntity.GetComponent<HealthComponent>().CurrentHealth = healthComponent.CurrentHealth;
        statsUpdatedEvent.TargetEntity.GetComponent<HealthComponent>().MaxHealth = healthComponent.MaxHealth;
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}