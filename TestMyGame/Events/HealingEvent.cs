using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class HealingEvent : IEvent
{
    public Entity TargetEntity { get; }
    public float HealingAmount { get; }

    public HealingEvent(Entity targetEntity, float healingAmount)
    {
        TargetEntity = targetEntity;
        HealingAmount = healingAmount;
    }
}