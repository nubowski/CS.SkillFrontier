using CoreLibs.Core;
using CoreLibs.Events;
using CoreLibs.Utilities;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class LocationActionProcessingSystem : BaseSystem
{
    public LocationActionProcessingSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        ComponentFilter.MustHaveComponents.AddRange(new[]
        {
            typeof(PlayerComponent),
            typeof(PositionComponent),
            typeof(LocationActionComponent)
        });
    }
    
    public override void Update(float deltaTime)
    {
        // Get all entities based on the component filter
        var entities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);

        // Process each entity
        foreach (var entity in entities)
        {
            ProcessEntity(entity, deltaTime);
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        var locationActionComponent = entity.GetComponent<LocationActionComponent>();

        switch(locationActionComponent.Action)
        {
            case LocationActionComponent.LocationAction.Grind:
                _eventManager.Emit(new StartIdleGrindingEvent(entity));
                Logger.Debug($"Emitted StartIdleGrindingEvent");
                break;
            case LocationActionComponent.LocationAction.Stop:
                _eventManager.Emit(new StopGrindingEvent(entity));
                Logger.Debug($"Emitted StopGrindingEvent");
                break;
            case LocationActionComponent.LocationAction.Explore:
                _eventManager.Emit(new StartExploringEvent(entity));
                Logger.Debug($"Emitted StartExploringEvent");
                break;
        }

        locationActionComponent.Action = LocationActionComponent.LocationAction.Idle;
    }
}