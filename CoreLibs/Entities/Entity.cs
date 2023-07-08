using CoreLibs.Components;

namespace CoreLibs.Entities;

public class Entity
{
    private static int _nextId = 0;

    public Entity()
    {
        Id = _nextId;
        Components = new Dictionary<Type, IComponent>();
    }
    
    public int Id { get; }
    public Dictionary<Type, IComponent> Components { get; private set; }
    

    public void AddComponent(IComponent component)
    {
        var type = component.GetType();
        if (Components.ContainsKey(type))
            throw new InvalidOperationException($"Entity already contains component of type {type}.");
        Components.Add(type, component);
    }

    public void RemoveComponent<T>() where T : IComponent
    {
        var type = typeof(T);
        if (!Components.ContainsKey(type))
            throw new InvalidOperationException($"Entity does not contain component of type {type}.");
        Components.Remove(type);
    }

    public bool HasComponent<T>() where T : IComponent
    {
        return Components.ContainsKey(typeof(T));
    }

    public T GetComponent<T>() where T : IComponent
    {
        var type = typeof(T);
        if (!Components.ContainsKey(type))
        {
            throw new InvalidOperationException($"Entity does not contain component of type {type}.");
        }
        return (T) Components[type];
    }

}