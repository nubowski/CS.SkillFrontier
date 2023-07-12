using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class CreateNpcEvent : IEvent
{
    public Entity Player { get; private set; }

    public CreateNpcEvent(Entity player)
    {
        Player = player;
    }
}