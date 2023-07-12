using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class NpcCreatedEvent : IEvent
{
    public Entity Npc { get; set; }

    public NpcCreatedEvent(Entity npc)
    {
        Npc = npc;
    }
}