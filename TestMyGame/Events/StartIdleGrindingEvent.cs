using CoreLibs.Entities;

namespace CoreLibs.Events.EventList;

public class StartIdleGrindingEvent : IEvent
{
    public Entity Player { get; private set; }

    public StartIdleGrindingEvent(Entity player)
    {
        Player = player;
    }
}