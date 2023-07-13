namespace CoreLibs;

public class Entity
{
    public EntityId EntityId { get; }

    // TODO need some props here? or only manager handles these all?

    public Entity(EntityId entityId)
    {
        EntityId = entityId;
    }
}