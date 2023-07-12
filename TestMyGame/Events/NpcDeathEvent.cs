using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class NpcDeathEvent : IEvent
{
    public Entity NpcEntity { get; }

    public NpcDeathEvent(Entity npcEntity)
    {
        NpcEntity = npcEntity;
    }
}