using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class LocationActionProcessingSystem : BaseSystem
{
    public LocationActionProcessingSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        ComponentFilter.MustHaveComponents.AddRange(new Type []
        {
            typeof(PlayerComponent),
            typeof(PositionComponent),
            typeof(LocationActionComponent)
        });
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        var locationActionComponent = entity.GetComponent<LocationActionComponent>();

        switch(locationActionComponent.Action)
        {
            case LocationActionComponent.LocationAction.Grind:
                _eventManager.Emit(new StartIdleGrindingEvent(entity));
                break;
            case LocationActionComponent.LocationAction.Stop:
                _eventManager.Emit(new StopGrindingEvent(entity));
                break;
            case LocationActionComponent.LocationAction.Explore:
                _eventManager.Emit(new StartExploringEvent(entity));
                break;
        }

        locationActionComponent.Action = LocationActionComponent.LocationAction.Idle;
    }
}