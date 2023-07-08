using CoreLibs.Entities;

namespace CoreLibs.Events.EventList;

public class EntityDestroyedEvent : IEvent
{
    public Entity Entity { get; }

    public EntityDestroyedEvent(Entity entity)
    {
        Entity = entity;
    }
}