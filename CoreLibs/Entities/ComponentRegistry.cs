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

        _componentEntityAssociations[type].Add(entity);
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
        if (_componentEntityAssociations.ContainsKey(type))
        {
            var entities = _componentEntityAssociations[type];
            Console.WriteLine($"Found {entities.Count} entities with component {type.Name}.");
            return entities;
        }
        else
        {
            Console.WriteLine($"No entities found with component {type.Name}.");
            return new List<Entity>();
        }
    }
    
    public List<Entity> GetEntitiesWithComponents(ComponentFilter filter)
    {
        // use a HashSet to eliminate duplicates.
        var entities = new HashSet<Entity>();

        foreach (var componentType in filter.MustHaveComponents)
        {
            if (_componentEntityAssociations.ContainsKey(componentType))
            {
                // add entities that have all the required component types.
                entities.IntersectWith(_componentEntityAssociations[componentType]);
            }
            else
            {
                // no entities - return an empty list.
                return new List<Entity>();
            }
        }

        // Filter out entities that have any of the MustNotHaveComponents.
        entities = new HashSet<Entity>(entities.Where(entity => !filter.MustNotHaveComponents.Any(entity.HasComponent)));

        return entities.ToList();
    }
}