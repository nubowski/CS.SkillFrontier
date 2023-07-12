using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems.IdleCombat;

public class GrindingSystem : BaseSystem
{
    public GrindingSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<StartIdleGrindingEvent>(HandleStartGrinding);

        ComponentFilter.MustHaveComponents.AddRange( new[]
        {
            typeof(PlayerComponent),
            typeof(CharacterComponent),
            typeof(PositionComponent),
        });
    }

    private void HandleStartGrinding(StartIdleGrindingEvent startIdleGrindingEvent)
    {
        // TODO delete these --v
        // we need to take the location entity to check its name?
        var locationId = startIdleGrindingEvent.Player.GetComponent<PositionComponent>().CurrentLocationId;
        var locName = _entityManager.GetEntityById(locationId).GetComponent<LocationComponent>().Name;
        var locDesc = _entityManager.GetEntityById(locationId).GetComponent<LocationComponent>().Description;

        var player = startIdleGrindingEvent.Player;
        _eventManager.Emit(new CreateNpcEvent(player));

        // Using this Id of the location to build and bring the spawn query and some advanced logic
    }
    

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}