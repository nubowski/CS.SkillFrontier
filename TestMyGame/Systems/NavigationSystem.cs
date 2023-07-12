using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using CoreLibs.Utilities;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class NavigationSystem : BaseSystem
{
    public NavigationSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<LocationSelectedEvent>(HandledLocationSelected);
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(PlayerComponent),
            typeof(PositionComponent)
        });
    }

    private void HandledLocationSelected(LocationSelectedEvent locationSelectedEvent)
    {
        Logger.Debug($"LocationSelectedEvent: {locationSelectedEvent.SelectedLocation}");
        var entities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);

        foreach (var entity in entities)
        {
            var positionComponent = entity.GetComponent<PositionComponent>();
            positionComponent.CurrentLocationId = locationSelectedEvent.SelectedLocation.Id;

            var locationName = locationSelectedEvent.SelectedLocation.GetComponent<LocationComponent>().Name;
            Logger.Log($"Player moved to the {locationName}");
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}