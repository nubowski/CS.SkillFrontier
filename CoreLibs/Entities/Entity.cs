using System.Text.Json;
using System.Text.Json.Serialization;
using CoreLibs.Components;

namespace CoreLibs.Entities;

public class Entity
{
    private static int _nextId = 0;
    private readonly Dictionary<Type, IComponent> _components = new();
    private readonly IComponentRegistry _componentRegistry;

    public Entity(IComponentRegistry componentRegistry, int? id = null)
    {
        Id = id ?? _nextId++;
        _componentRegistry = componentRegistry;
    }
    
    public int Id { get; set; }


    public void AddComponent<T>(T component) where T : IComponent
    {
        _components[typeof(T)] = component;
        _componentRegistry.RegisterComponent<T>(this);
        
        // Log the component details after adding
        Console.WriteLine($"Component added: {component}");
    }

    public void RemoveComponent<T>() where T : IComponent
    {
        _components.Remove(typeof(T));
        _componentRegistry.UnregisterComponent<T>(this);
    }


    public T GetComponent<T>() where T : IComponent
    {
        return (_components.TryGetValue(typeof(T), out var component) ? (T) component : default)!;
    }

    public bool HasComponent<T>() where T : IComponent
    {
        return _components.ContainsKey(typeof(T));
    }
    
    public bool HasComponent(Type componentType)
    {
        return _components.ContainsKey(componentType);
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
    
    public EntityData ToEntityData()
    {
        var data = new EntityData
        {
            Id = Id,
            Components = new Dictionary<string, string>()
        };

        foreach (var component in _components)
        {
            var serializedComponent = JsonSerializer.Serialize(component.Value, component.Value.GetType());
            data.Components.Add(component.Key.AssemblyQualifiedName, serializedComponent);
        }

        return data;
    }
    
    public void FromEntityData(EntityData entityData)
    {
        Id = entityData.Id;

        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.Never
        };

        foreach (var component in entityData.Components)
        {
            var componentType = Type.GetType(component.Key, true); // This will throw an exception if the type can't be found
            var deserializedComponent = JsonSerializer.Deserialize(component.Value, componentType, options);
            _components[componentType] = (IComponent)deserializedComponent;
        }
    }
}