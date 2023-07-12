using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using CoreLibs.Utilities;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems;

public class LocationSelectionSystem : BaseSystem
{
    private bool _locationsSelected = false;
    public LocationSelectionSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _entityManager = entityManager;
        _eventManager.AddListener<KeypressEvent>(HandleKeypress);
        
        ComponentFilter.MustHaveComponents.AddRange(new[]
        {
            typeof(LocationComponent),
        });
    }

    private void HandleKeypress(KeypressEvent keypressEvent)
    {
        if (keypressEvent.Key == ConsoleKey.M)
        {
            SelectLocation();
            _locationsSelected = true;
        }
    }
    
    public override void Update(float deltaTime)
    {
        // Zzz z zZzz Zzz
    }

    private void SelectLocation()
    {
        // Get all entities having a LocationComponent
        var locationEntities = _entityManager.GetEntitiesBasedOnFilter(ComponentFilter);

        // Create a dictionary to map the indices to the location entities
        var locationDict = new Dictionary<int, Entity>();
    
        Console.WriteLine("Select location:");

        int index = 1;
        foreach (var entity in locationEntities)
        {
            var locationComponent = entity.GetComponent<LocationComponent>();
            Console.WriteLine($"{index} - {locationComponent.Name}");

            // index-entity mapping in the dictionary
            locationDict.Add(index, entity);

            index++;
        }

        int locationChoice = Convert.ToInt32(Console.ReadLine());

        if (locationDict.ContainsKey(locationChoice))
        {
            var selectedLocationEntity = locationDict[locationChoice];
        
            // emits event here
            _eventManager.Emit(new LocationSelectedEvent(selectedLocationEntity));
        }
        else
        {
            Logger.Log($"Invalid location selection.");
        }
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}