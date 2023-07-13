namespace CoreLibs;

public interface IComponent
{
    
}

public interface IInitializer : IDisposable
{
    World World { get; set; }
    
    // system first call before update
    void OnAwake();
}

public interface ISystem : IInitializer
{
    // system on each update cycle
    void OnUpdate();
}