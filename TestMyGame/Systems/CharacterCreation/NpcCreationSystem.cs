using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Events;

namespace TestMyGame.Systems.CharacterCreation;

public class NpcCreationSystem : BaseSystem
{
    private readonly NpcFactory _npcFactory;
    private const string BestiaryFilePath = "./Data/Bestiary.json";
    
    public NpcCreationSystem(NpcFactory npcFactory ,EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _npcFactory = npcFactory;
        
        _eventManager.AddListener<CreateNpcEvent>(CreateNpc);
    }

    private void CreateNpc(CreateNpcEvent createNpcEvent)
    {
        // making a doll-npc
        var npc = _npcFactory.CreateNpc();
        
        // add all logic whatever we want or need to change (race, components, procedural generation, whatever we want with the RAW entity)
        
        
        // I NEED SOME MAGIC HERE !!! add some methods for make this kinda target-randomly despite on pool of
        
        
        // pass this `npc` with the event for next step
        _eventManager.Emit(new NpcCreatedEvent(npc));

    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}