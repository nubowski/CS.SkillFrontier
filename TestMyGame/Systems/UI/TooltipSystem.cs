using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;
using TestMyGame.Components.Stimul;

namespace TestMyGame.Systems.UI;

public class TooltipSystem : BaseSystem
{
    public TooltipSystem(EntityManager entityManager, EventManager eventManager)
        : base(entityManager, eventManager)
    {
        _eventManager = eventManager;
        _entityManager = entityManager;
        _eventManager.AddListener<KeypressEvent>(HandleKeypress);
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(PlayerComponent),
            typeof(CharacterComponent)
        });
    }

    private void HandleKeypress(KeypressEvent keypressEvent)
    {
        if (keypressEvent.Key == ConsoleKey.T) // key to display the tooltip
        {
            var entities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);
            foreach (var entity in entities)
            {
                // Print the entity's information to the console
                Console.WriteLine($"Name: {entity.GetComponent<NameComponent>()?.Name ?? "N/A"}");
                Console.WriteLine($"Level: {entity.GetComponent<LevelComponent>()?.Level ?? 0}");
                Console.WriteLine($"Experience: {entity.GetComponent<ExperienceComponent>()?.ExperiencePoints ?? 0}");
                Console.WriteLine($"Race: {entity.GetComponent<RaceComponent>()?.Race.ToString() ?? "N/A"}");
                Console.WriteLine($"Strength: {entity.GetComponent<StrengthAttributeComponent>()?.Strength ?? 0}");
                Console.WriteLine($"Toughness: {entity.GetComponent<ToughnessAttributeComponent>()?.Toughness ?? 0}");
                Console.WriteLine($"Agility: {entity.GetComponent<AgilityAttributeComponent>()?.Agility ?? 0}");
                Console.WriteLine($"Intelligence: {entity.GetComponent<IntelligenceAttributeComponent>()?.Intelligence ?? 0}");
                Console.WriteLine($"Mind: {entity.GetComponent<MindAttributeComponent>()?.Mind ?? 0}");
                Console.WriteLine($"Luck: {entity.GetComponent<LuckAttributeComponent>()?.Luck ?? 0}");
            }
        }
    }

    public override void Update(float deltaTime)
    {
        // none
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}