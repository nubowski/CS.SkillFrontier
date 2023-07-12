using CoreLibs.Components;
using CoreLibs.Entities;
using CoreLibs.Events;

namespace CoreLibs.Systems;

public abstract class BaseSystem : ISystem
{
    protected EntityManager _entityManager;
    protected EventManager _eventManager;
    public ComponentFilter ComponentFilter { get; } = new ComponentFilter();
    public int Order { get; set; }
    public virtual bool Enabled { get; set; } = true; // all systems are enabled by default

    protected BaseSystem(EntityManager entityManager, EventManager eventManager)
    {
        _entityManager = entityManager;
        _eventManager = eventManager;
    }

    public virtual void Update(float deltaTime)
    {
        var entities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);
        foreach(var entity in entities)
        {
            ProcessEntity(entity, deltaTime);
        }
    }
    
    public abstract void ProcessEntity(Entity entity, float deltaTime);
}