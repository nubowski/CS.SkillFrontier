using CoreLibs.Core;
using CoreLibs.Events;
using CoreLibs.Utilities;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class LocationActionSystem : BaseSystem
{
    public LocationActionSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<KeypressEvent>(HandleKeypress);
        
        ComponentFilter.MustHaveComponents.AddRange(new[]
        {
            typeof(PlayerComponent),
            typeof(PositionComponent)
        });
    }

    private void HandleKeypress(KeypressEvent keypressEvent)
    {
        Logger.Debug($"Received keypress event: {keypressEvent.Key}");
        
        var playerEntities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);
        
        Logger.Debug($"Found {playerEntities.Count} player entities");

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
            
            Logger.Debug($"Updated action to: {locationActionComponent.Action}");
            
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}