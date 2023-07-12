using CoreLibs.Entities;

namespace CoreLibs.Events.EventList;

public class StopGrindingEvent : IEvent
{
    public Entity Player { get; private set; }

    public StopGrindingEvent(Entity player)
    {
        Player = player;
    }
}