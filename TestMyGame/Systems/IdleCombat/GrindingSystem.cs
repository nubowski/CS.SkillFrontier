using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems.IdleCombat;

public class GrindingSystem : BaseSystem
{
    public GrindingSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _eventManager.AddListener<StartIdleGrindingEvent>(HandleStartGrinding);
        
        ComponentFilter.MustHaveComponents.AddRange( new Type[]
        {
            typeof(PlayerComponent),
            typeof(CharacterComponent),
            typeof(PositionComponent),
        });
    }

    private void HandleStartGrinding(StartIdleGrindingEvent startIdleGrindingEvent)
    {
        var player = startIdleGrindingEvent.Player;
        var positionComponent = player.GetComponent<PositionComponent>();
        var locationId = positionComponent.CurrentLocationId;
        
        // Using this Id of the location to build and bring the spawn query and some advanced logic
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}