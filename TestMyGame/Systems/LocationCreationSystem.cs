using CoreLibs;
using TestMyGame.Components;
using TestMyGame.Utility;

namespace TestMyGame.Systems;

public class LocationCreationSystem : BaseSystem
{
    private Filter _filter;
    private const string LocationsFilePath = "./Data/Locations.json";
    private bool _locationsCreated = false;

    public override void OnAwake()
    {
        this._filter = this.World.Filter.Add<PlayerComponent>();
        if (_locationsCreated) return;
        CreateLocations();
        _locationsCreated = true;
    }

    public override void OnUpdate(float deltaTime)
    {
        // no need for this in OnUpdate if we're only creating locations once?
    }

    private void CreateLocations()
    {
        List<LocationData> locationDataList = LocationDataLoader.LoadLocations(LocationsFilePath);

        foreach (var locationData in locationDataList)
        {
            var location = World.EntityManager.CreateEntity();
            World.EntityManager.AddComponent(location, new LocationComponent
            {
                Name = locationData.Name,
                Description = locationData.Description,
                Biome = locationData.Biome,
                Level = locationData.Level
            });

            Console.WriteLine($"{locationData.Name} was created!");
        }
    }
}