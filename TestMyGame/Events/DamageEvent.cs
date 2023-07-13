using CoreLibs.Core;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class DamageEvent : IEvent
{
    public Entity TargetEntity { get; }
    public float DamageAmount { get; }

    public DamageEvent(Entity targetEntity, float damageAmount)
    {
        TargetEntity = targetEntity;
        DamageAmount = damageAmount;
    }
}