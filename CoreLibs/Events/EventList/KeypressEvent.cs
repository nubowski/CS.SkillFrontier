namespace CoreLibs.Events.EventList;

public class KeypressEvent : IEvent
{
    public ConsoleKey Key { get; private set; }

    public KeypressEvent(ConsoleKey key)
    {
        Key = key;
    }
}