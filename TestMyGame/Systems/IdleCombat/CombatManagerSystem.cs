using CoreLibs.Core;
using CoreLibs.Events;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems.IdleCombat;

public class CombatManagerSystem : BaseSystem
{
    public CombatManagerSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<NpcCreatedEvent>(StartCombat);
    }

    private void StartCombat(NpcCreatedEvent npcCreatedEvent)
    {
        var playerEntity = npcCreatedEvent.Player;
        var npcEntity = npcCreatedEvent.Npc; // Placeholder, replace with your own method

        playerEntity.GetComponent<CombatComponent>().Target = npcEntity;
        npcEntity.GetComponent<CombatComponent>().Target = playerEntity;
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}