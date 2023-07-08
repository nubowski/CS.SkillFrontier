namespace CoreLibs.Systems;

public class SystemManager
{
    private readonly List<ISystem> _systems = new List<ISystem>();

    public void AddSystem(ISystem system)
    {
        _systems.Add(system);
    }

    public void Update(float deltaTime)
    {
        foreach (var system in _systems)
        {
            system.Update(deltaTime);
        }
    }
}