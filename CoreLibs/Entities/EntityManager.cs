using CoreLibs.Components;
using CoreLibs.Events;
using CoreLibs.Events.EventList;

namespace CoreLibs.Entities;

public class EntityManager
{
    private List<Entity> _entities = new List<Entity>();
    private EventManager _eventManager;
    private IComponentRegistry _componentRegistry;

    public EntityManager(IComponentRegistry componentRegistry, EventManager eventManager)
    {
        _componentRegistry = componentRegistry;
        _eventManager = eventManager;
    }

    public Entity CreateEntity(int? id = null)
    {
        var entity = new Entity(_componentRegistry, id);
        _entities.Add(entity);
        return entity;
    }

    public void DestroyEntity(Entity entity)
    {
        // remove all components from entity
        entity.RemoveAllComponents();
        _entities.Remove(entity);
        _eventManager.Emit(new EntityDestroyedEvent(entity));
    }
    
    public Entity CreateEntityFromData(EntityData entityData)
    {
        var entity = CreateEntity();
        entity.FromEntityData(entityData);
        return entity;
    }

    public void OnEntityDestroy(EntityDestroyedEvent entityDestroyedEvent)
    {
        Console.WriteLine($"The entity {entityDestroyedEvent.Entity.Id} is destroyed!");
    }

    public List<Entity> GetEntitiesBasedOnFilter(ComponentFilter filter)
    {
        var entitiesWithComponents = new List<Entity>();

        foreach (var entity in _entities)
        {
            if (filter.MayHaveComponents.Any(x => entity.HasComponent(x)) ||
                filter.MustHaveComponents.All(x => entity.HasComponent(x)) &&
                filter.MustNotHaveComponents.All(x => !entity.HasComponent(x)))
            {
                entitiesWithComponents.Add(entity);
            }
        }

        return entitiesWithComponents;
    }
    
    public Entity GetEntityById(int id)
    {
        // assuming _entities is a List<Entity>
        return _entities.First(e => e.Id == id);
    }
}