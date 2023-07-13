namespace CoreLibs;

public class SystemManager
{
    private List<ISystem> _systems = new List<ISystem>();
    
    public void RegisterSystem(ISystem system)
    {
        _systems.Add(system);
    }

    public void Update(float deltaTime)
    {
        foreach (var system in _systems)
        {
            system.OnUpdate(deltaTime);
        }
    }

    // methods for managing systems...
}