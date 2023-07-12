using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class StopGrindingEvent : IEvent
{
    public Entity Player { get; private set; }

    public StopGrindingEvent(Entity player)
    {
        Player = player;
    }
}