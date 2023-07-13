using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class StatsUpdatedEvent : IEvent
{
    public StatsUpdatedEvent(Entity targetEntity)
    {
        TargetEntity = targetEntity;
    }

    public Entity TargetEntity { get; }
}