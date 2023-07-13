namespace CoreLibs;

public class ComponentStore
{
    private Dictionary<Type, Dictionary<EntityId, IComponent>> _componentsByType =
        new Dictionary<Type, Dictionary<EntityId, IComponent>>();

    public void AddComponent<T>(EntityId entityId, T component) where T : IComponent
    {
        if (!_componentsByType.TryGetValue(typeof(T), out var components))
        {
            components = new Dictionary<EntityId, IComponent>();
            _componentsByType[typeof(T)] = components;
        }

        components[entityId] = component;
    }

    public bool RemoveComponent<T>(EntityId entityId) where T : IComponent
    {
        return _componentsByType.TryGetValue(typeof(T), out var components) && components.Remove(entityId);
    }

    public bool HasComponent<T>(EntityId entityId) where T : IComponent
    {
        return _componentsByType.TryGetValue(typeof(T), out var components) && components.ContainsKey(entityId);
    }

    public T GetComponent<T>(EntityId entityId) where T : IComponent
    {
        if (_componentsByType.TryGetValue(typeof(T), out var components) && components.TryGetValue(entityId, out var component))
        {
            return (T)component;
        }

        throw new ArgumentException($"Entity {entityId} does not have component {typeof(T)}.");
    }
    
    public void RemoveAllComponents(EntityId entityId)
    {
        foreach (var components in _componentsByType.Values)
        {
            components.Remove(entityId);
        }
    }

    public IEnumerable<EntityId> GetEntitiesWithComponent<T>() where T : IComponent
    {
        if (_componentsByType.TryGetValue(typeof(T), out var components))
        {
            foreach (var entityId in components.Keys)
            {
                yield return entityId;
            }
        }
    }
}