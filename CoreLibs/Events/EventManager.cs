namespace CoreLibs.Events;

public class EventManager
{
    private Dictionary<Type, List<Action<IEvent>>> _listeners = new Dictionary<Type, List<Action<IEvent>>>();
    private HashSet<Type> _emittedEvents = new HashSet<Type>(); // track of emitted events

    public void AddListener<T>(Action<T> listener) where T : IEvent
    {
        var eventType = typeof(T);
        if (!_listeners.ContainsKey(eventType))
        {
            _listeners[eventType] = new List<Action<IEvent>>();
        }
        _listeners[eventType].Add((e) => listener((T)e));
    }

    public void RemoveListener<T>(Action<T> listener) where T : IEvent
    {
        var eventType = typeof(T);
        if (!_listeners.ContainsKey(eventType)) return;

        _listeners[eventType].Remove((e) => listener((T)e));

        if (_listeners[eventType].Count == 0)
        {
            _listeners.Remove(eventType);
        }
    }

    public void Emit<T>(T emittedEvent) where T : IEvent
    {
        var eventType = typeof(T);
        if (!_listeners.ContainsKey(eventType)) return;

        foreach (var listener in _listeners[eventType])
        {
            listener(emittedEvent);
        }

        _emittedEvents.Add(eventType); // event type as emitted
    }

    public bool HasEvent<T>() where T : IEvent // event type has been emitted
    {
        var eventType = typeof(T);
        return _emittedEvents.Contains(eventType);
    }
}