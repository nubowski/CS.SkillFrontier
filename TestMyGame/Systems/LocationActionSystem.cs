using System.ComponentModel;
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

            switch (keypressEvent.Key)
            {
                case ConsoleKey.G:
                    locationActionComponent.Action = LocationActionComponent.LocationAction.Grind;
                    break;
                
                case ConsoleKey.S:
                    locationActionComponent.Action = LocationActionComponent.LocationAction.Stop;
                    break;
                
                case ConsoleKey.E:
                    locationActionComponent.Action = LocationActionComponent.LocationAction.Explore; 
                    break;
            }
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}