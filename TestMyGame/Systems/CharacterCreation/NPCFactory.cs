using CoreLibs.Entities;
using TestMyGame.Components;
using TestMyGame.Components.Stimul;

namespace TestMyGame.Systems.CharacterCreation;

public class NPCFactory
{
    private readonly EntityManager _entityManager;
    private readonly ComponentRegistry _componentRegistry;

    public NPCFactory(EntityManager entityManager, ComponentRegistry componentRegistry)
    {
        _entityManager = entityManager;
        _componentRegistry = componentRegistry;
    }

    public Entity CreateNPC(string npcType)
    {
        var entity = _entityManager.CreateEntity();

        // STIMUL attributes
        entity.AddComponent(new StrengthAttributeComponent());
        entity.AddComponent(new ToughnessAttributeComponent());
        entity.AddComponent(new IntelligenceAttributeComponent());
        entity.AddComponent(new MindAttributeComponent());
        entity.AddComponent(new LuckAttributeComponent());
        entity.AddComponent(new AgilityAttributeComponent());

        // Common components
        entity.AddComponent(new CharacterComponent());
        entity.AddComponent(new HealthComponent());
        entity.AddComponent(new LevelComponent());
        entity.AddComponent(new RaceComponent());
        // entity.AddComponent(new CharacterTypeComponent);

        // NPC-specific components
        entity.AddComponent(new NPCTypeComponent());
        entity.AddComponent(new PositionComponent());

        // TODO: Add any other NPC-specific components

        return entity;
    }
}