using CoreLibs.Entities;
using TestMyGame.Components;
using TestMyGame.Components.Stimul;

namespace TestMyGame.Systems.CharacterCreation;

public class CharacterFactory
{
    private readonly EntityManager _entityManager;
    private readonly ComponentRegistry _componentRegistry;

    public CharacterFactory(EntityManager entityManager, ComponentRegistry componentRegistry)
    {
        _entityManager = entityManager;
        _componentRegistry = componentRegistry;
    }

    public Entity CreateCharacter()
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
        entity.AddComponent(new NameComponent());
        entity.AddComponent(new GenderComponent());
        entity.AddComponent(new GpsComponent());
        entity.AddComponent(new PositionComponent());
        
        // TODO make this grouped `by` or Im not sure how to handle dozens of different unclassified components on `live`
        
        return entity;
    }
}