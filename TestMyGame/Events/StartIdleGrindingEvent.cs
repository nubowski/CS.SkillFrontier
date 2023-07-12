using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class StartIdleGrindingEvent : IEvent
{
    public Entity Player { get; private set; }

    public StartIdleGrindingEvent(Entity player)
    {
        Player = player;
    }
}