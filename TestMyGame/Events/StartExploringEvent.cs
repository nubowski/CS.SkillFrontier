using CoreLibs.Entities;

namespace CoreLibs.Events.EventList;

public class StartExploringEvent : IEvent
{
    public Entity Player { get; private set; }

    public StartExploringEvent(Entity player)
    {
        Player = player;
    }
}