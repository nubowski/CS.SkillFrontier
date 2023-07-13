using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class PlayerDeathEvent : IEvent
{
    public PlayerDeathEvent(Entity player)
    {
        Player = player;
    }

    public Entity Player { get; set; }    
}