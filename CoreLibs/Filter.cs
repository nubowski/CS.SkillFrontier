using System.Collections;

namespace CoreLibs;

public class Filter : IEnumerable<Entity>
{
    private readonly EntityManager _entityManager;
    private readonly List<Type> _includingTypes;
    private readonly List<Type> _excludingTypes;

    public Filter(EntityManager entityManager)
    {
        _entityManager = entityManager;
        _includingTypes = new List<Type>();
        _excludingTypes = new List<Type>();
    }

    public Filter Add<T>() where T : IComponent
    {
        _includingTypes.Add(typeof(T));
        return this;
    }

    public Filter Not<T>() where T : IComponent
    {
        _excludingTypes.Add(typeof(T));
        return this;
    }

    public IEnumerator<Entity> GetEnumerator()
    {
        foreach (var entity in _entityManager.GetAllEntities())
        {
            bool matchesIncluding = _includingTypes.All(type => _entityManager.HasComponent(entity.EntityId, type));
            bool matchesExcluding = _excludingTypes.All(type => !_entityManager.HasComponent(entity.EntityId, type));

            if (matchesIncluding && matchesExcluding)
            {
                yield return entity;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}