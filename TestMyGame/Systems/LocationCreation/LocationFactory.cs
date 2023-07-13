using CoreLibs.Core;
using TestMyGame.Components;

namespace TestMyGame.Systems.LocationCreation;

public class LocationFactory
{
    private readonly EntityManager _entityManager;

    public LocationFactory(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public Entity CreateLocation(string name, string description)
    {
        var location = _entityManager.CreateEntity();

        location.AddComponent(new LocationComponent(name, description));
        
        
        return location;
    }
}