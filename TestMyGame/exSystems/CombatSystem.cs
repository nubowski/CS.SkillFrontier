using CoreLibs.Core;
using CoreLibs.Events;
using CoreLibs.Utilities;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class CombatSystem : BaseSystem
{
    public CombatSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<NpcCreatedEvent>(BeginCombat);
    }

    private void BeginCombat(NpcCreatedEvent npcCreatedEvent)
    {
        var playerEntity = npcCreatedEvent.Player;
        var npcEntity = npcCreatedEvent.Npc;
        
        Logger.Log($"Seems like a {npcEntity.GetComponent<NameComponent>().Name} is attacking!");
        
        var name = npcEntity.GetComponent<NameComponent>().Name;
        var race = npcEntity.GetComponent<RaceComponent>().Race;
        var gender = npcEntity.GetComponent<GenderComponent>().Gender;
        var description = npcEntity.GetComponent<DescriptionComponent>().Description;
        var currentHP = npcEntity.GetComponent<HealthComponent>().CurrentHealth;
        var maxHP = npcEntity.GetComponent<HealthComponent>().MaxHealth;
        
        
        Logger.Log($"Name: {name}");
        Logger.Log($"Race: {race}");
        Logger.Log($"Gender: {gender}");
        Logger.Log($"Description: {description}");
        Logger.Log($"And has {currentHP} of max {maxHP}");

        // Assuming turns are simply alternating for simplicity
        PlayerAttack(playerEntity, npcEntity);
    }

    private void PlayerAttack(Entity playerEntity, Entity npcEntity)
    {
        // For now, let's assume a flat damage of 10 per attack.
        float damage = 10;
        _eventManager.Emit(new DamageEvent(npcEntity, damage));
        Logger.Log($"{playerEntity.GetComponent<NameComponent>().Name} hits for {damage} damage");

        // Check if NPC is still alive after taking damage
        var npcHealth = npcEntity.GetComponent<HealthComponent>();
        if (npcHealth.CurrentHealth > 0)
        {
            // After the player attacks, it's the NPC's turn
            NpcAttack(npcEntity, playerEntity);
        }
        else
        {
            // The NPC is dead, combat is over
            _eventManager.Emit(new DeathEvent(npcEntity));
        }
    }

    private void NpcAttack(Entity npcEntity, Entity playerEntity)
    {
        // NPCs also do a flat damage of 10 for now
        float damage = 10;
        _eventManager.Emit(new DamageEvent(playerEntity, damage));
        Logger.Log($"{npcEntity.GetComponent<NameComponent>().Name} make a damage of {damage}");

        // Check if player is still alive after taking damage
        var playerHealth = playerEntity.GetComponent<HealthComponent>();
        if (playerHealth.CurrentHealth > 0)
        {
            // After the NPC attacks, it's the player's turn again
            PlayerAttack(playerEntity, npcEntity);
        }
        else
        {
            // The player is dead, combat is over
            // _eventManager.Emit(new DeathEvent(playerEntity));
            _eventManager.Emit(new PlayerDeathEvent(playerEntity));
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}