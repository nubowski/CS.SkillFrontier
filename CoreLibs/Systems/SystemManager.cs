namespace CoreLibs.Systems;

public class SystemManager
{
    private SortedSet<ISystem> _systems = new SortedSet<ISystem>(new SystemComparer());

    public void AddSystem(ISystem system)
    {
        _systems.Add(system);
    }

    public void RemoveSystem(ISystem system)
    {
        _systems.Remove(system);
    }

    public void Update(float deltaTime)
    {
        foreach (var system in _systems)
        {
            system.Update(deltaTime);
        }
    }
}