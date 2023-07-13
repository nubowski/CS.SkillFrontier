using CoreLibs.Core;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class StartExploringEvent : IEvent
{
    public Entity Player { get; private set; }

    public StartExploringEvent(Entity player)
    {
        Player = player;
    }
}