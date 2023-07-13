using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class NpcCreatedEvent : IEvent
{
    public NpcCreatedEvent(Entity npc, Entity player)
    {
        Npc = npc;
        Player = player;
    }

    public Entity Npc { get; set; }
    public Entity Player { get; set; }
    
}