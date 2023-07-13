namespace CoreLibs;

public class World
{
    public EntityManager EntityManager { get; private set; }
    private List<ISystem> _systems;
    public Filter Filter { get; private set; }

    public World()
    {
        EntityManager = new EntityManager();
        _systems = new List<ISystem>();
        Filter = new Filter(EntityManager);
    }

    public T AddSystem<T>(T system) where T : class, ISystem
    {
        system.World = this;
        _systems.Add(system);
        return system;
    }

    public void AwakeSystems()
    {
        foreach(var system in _systems)
        {
            system.OnAwake();
        }
    }

    public void UpdateSystems(float deltaTime)
    {
        foreach(var system in _systems)
        {
            system.OnUpdate(deltaTime);
        }
    }

    public void DisposeSystems()
    {
        for (int i = _systems.Count - 1; i >= 0; --i)
        {
            _systems[i].Dispose();
        }
        _systems.Clear();
    }
}