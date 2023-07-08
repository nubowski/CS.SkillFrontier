using System.Collections;
using CoreLibs.Components;

namespace CoreLibs.Entities;

public class Entity
{
    private static int _nextId = 0;
    private readonly Dictionary<Type, IComponent> _components = new();
    private readonly IComponentRegistry _componentRegistry;

    public Entity(IComponentRegistry componentRegistry)
    {
        Id = _nextId++;
        _componentRegistry = componentRegistry;
    }
    
    public int Id { get; }
    
    
    public void AddComponent<T>(T component) where T : IComponent
    {
        _components[typeof(T)] = component;
        _componentRegistry.RegisterComponent<T>(this);
    }

    public void RemoveComponent<T>() where T : IComponent
    {
        _components.Remove(typeof(T));
        _componentRegistry.UnregisterComponent<T>(this);
    }


    public T GetComponent<T>() where T : IComponent
    {
        return _components.TryGetValue(typeof(T), out var component) ? (T) component : default;
    }

    public bool HasComponent<T>() where T : IComponent
    {
        return _components.ContainsKey(typeof(T));
    }

    public List<Type> GetComponents()
    {
        return _components.Keys.ToList();
    }

    public void RemoveAllComponents()
    {
        foreach (var componentType in _components.Keys.ToList()) // to list to avoid some collection modification issues
        {
            _componentRegistry.UnregisterComponent(componentType, this);
        }
        _components.Clear();
    }
}