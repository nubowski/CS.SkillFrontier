using CoreLibs.Components;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Systems;

namespace CoreLibs;

public class World
{
    public EntityManager EntityManager { get; }
    public IComponentRegistry ComponentRegistry { get; }
    public EventManager EventManager { get; }
    public SystemManager SystemManager { get; }

    public World(EntityManager entityManager, IComponentRegistry componentRegistry, EventManager eventManager)
    {
        EntityManager = entityManager;
        ComponentRegistry = componentRegistry;
        EventManager = eventManager;
        SystemManager = new SystemManager();
    }

    public void Update(float deltaTime)
    {
        SystemManager.Update(deltaTime);
    }

    public void AddSystem<T>(T system) where T : ISystem
    {
        SystemManager.AddSystem(system);
    }
}
