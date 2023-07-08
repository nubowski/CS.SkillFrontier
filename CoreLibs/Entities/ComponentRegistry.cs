using CoreLibs.Components;

namespace CoreLibs.Entities;

public class ComponentRegistry : IComponentRegistry
{
    private readonly Dictionary<Type, List<Entity>> _componentEntityAssociations = new();

    public void RegisterComponent<T>(Entity entity) where T : IComponent
    {
        var type = typeof(T);
        if (!_componentEntityAssociations.ContainsKey(type))
        {
            _componentEntityAssociations[type] = new List<Entity>();
        }
    }

    public void UnregisterComponent<T>(Entity entity) where T : IComponent
    {
        var type = typeof(T);
        if (_componentEntityAssociations.ContainsKey(type))
        {
            _componentEntityAssociations[type].Remove(entity);
        }
    }

    public void UnregisterComponent(Type componentType, Entity entity)
    {
        if (_componentEntityAssociations.ContainsKey(componentType))
        {
            _componentEntityAssociations[componentType].Remove(entity);
        }
    }

    public List<Entity> GetEntitiesWithComponent<T>() where T : IComponent
    {
        var type = typeof(T);
        return _componentEntityAssociations.ContainsKey(type) ? _componentEntityAssociations[type] : new List<Entity>();
    }
}