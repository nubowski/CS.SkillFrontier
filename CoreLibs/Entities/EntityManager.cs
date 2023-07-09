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

    public Entity CreateEntity()
    {
        var entity = new Entity(_componentRegistry);
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
    
    

    public void OnEntityDestroy(EntityDestroyedEvent entityDestroyedEvent)
    {
        Console.WriteLine($"The entity {entityDestroyedEvent.Entity.Id} is destroyed!");
    }
}