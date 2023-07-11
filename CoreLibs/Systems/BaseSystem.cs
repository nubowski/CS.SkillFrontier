using CoreLibs.Components;

namespace CoreLibs.Systems;

public abstract class BaseSystem : ISystem
{
    
    protected ComponentFilter ComponentFilter { get; } = new ComponentFilter();
    public virtual int Order { get; set; } // virtual and settable
    
    public abstract void Update(float deltaTime);
    
    // More common functionalities across systems can be added here.   
}