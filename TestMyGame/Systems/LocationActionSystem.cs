using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class LocationActionSystem : BaseSystem
{
    public LocationActionSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<KeypressEvent>(HandleKeypress);
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(PlayerComponent),
            typeof(PositionComponent)
        });
    }

    private void HandleKeypress(KeypressEvent keypressEvent)
    {
        var playerEntities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);

        foreach (var player in playerEntities)
        {
            if (!player.HasComponent<LocationActionComponent>())
            {
                player.AddComponent(new LocationActionComponent());
            }

            var locationActionComponent = player.GetComponent<LocationActionComponent>();

            locationActionComponent.Action = keypressEvent.Key switch
            {
                ConsoleKey.G => LocationActionComponent.LocationAction.Grind,
                ConsoleKey.S => LocationActionComponent.LocationAction.Stop,
                ConsoleKey.E => LocationActionComponent.LocationAction.Explore,
                _ => locationActionComponent.Action
            };
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}