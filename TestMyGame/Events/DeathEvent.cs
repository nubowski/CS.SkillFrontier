using CoreLibs.Core;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class DeathEvent : IEvent
{
    public Entity DeadEntity { get; }

    public DeathEvent(Entity deadEntity)
    {
        DeadEntity = deadEntity;
    }
}