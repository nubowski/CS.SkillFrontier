using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Systems;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class CombatSystem : BaseSystem
{
    public CombatSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _entityManager = entityManager;
        
        _eventManager.AddListener<NpcCreatedEvent>(HandleStartFight);
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(CharacterComponent),
        });
    }

    private void HandleStartFight(NpcCreatedEvent npcCreatedEvent)
    {
        Entity npc = npcCreatedEvent.Npc;
        
        var name = npc.GetComponent<NameComponent>().Name;
        var race = npc.GetComponent<RaceComponent>().Race;
        var gender = npc.GetComponent<GenderComponent>().Gender;
        var description = npc.GetComponent<DescriptionComponent>().Description;
        
        

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Race: {race}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Description: {description}");
        
    }

    public override void Update(float deltaTime)
    {
        // combat goes here
    }
    
    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}