namespace CoreLibs;

public class EntityManager
{
    private int _nextId = 0;
    private int _nextGen = 1;
    private Dictionary<EntityId, Entity> _entities = new Dictionary<EntityId, Entity>();
    private ComponentStore _componentStore = new ComponentStore();

    public Entity CreateEntity()
    {
        var entity = new Entity(new EntityId(_nextId++, _nextGen++));
        _entities[entity.EntityId] = entity;
        return entity;
    }

    public void DestroyEntity(Entity entity)
    {
        _entities.Remove(entity.EntityId);
        _componentStore.RemoveAllComponents(entity.EntityId);
    }

    public IEnumerable<Entity> GetAllEntities()
    {
        return _entities.Values;
    }

    public void AddComponent<T>(Entity entity, T component) where T : IComponent
    {
        _componentStore.AddComponent(entity.EntityId, component);
    }

    public bool RemoveComponent<T>(Entity entity) where T : IComponent
    {
        return _componentStore.RemoveComponent<T>(entity.EntityId);
    }

    public bool HasComponent(EntityId entityId, Type componentType)
    {
        var method = _componentStore.GetType().GetMethod(nameof(_componentStore.HasComponent));
        var generic = method.MakeGenericMethod(componentType);
        return (bool)generic.Invoke(_componentStore, new object[] { entityId });
    }

    public T GetComponent<T>(Entity entity) where T : IComponent
    {
        return _componentStore.GetComponent<T>(entity.EntityId);
    }

    public IEnumerable<Entity> GetEntitiesWithComponent<T>() where T : IComponent
    {
        var entityIds = _componentStore.GetEntitiesWithComponent<T>();
        foreach (var entityId in entityIds)
        {
            if (_entities.TryGetValue(entityId, out var entity))
            {
                yield return entity;
            }
        }
    }
}