using CoreLibs.Entities;

namespace CoreLibs.Components;

public interface IComponentRegistry
{
    void RegisterComponent<T>(Entity entity) where T : IComponent;
    void UnregisterComponent<T>(Entity entity) where T : IComponent;
    void UnregisterComponent(Type componentType, Entity entity);
    List<Entity> GetEntitiesWithComponent<T>() where T : IComponent;
    public List<Entity> GetEntitiesWithComponents(ComponentFilter filter);
}