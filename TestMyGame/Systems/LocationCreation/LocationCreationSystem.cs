using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems.LocationCreation
{
    public class LocationCreationSystem : BaseSystem
    {
        private readonly LocationFactory _locationFactory;
        private bool _locationsCreated = false;
        private const string LocationsFilePath = "./Data/Locations.json";

        public LocationCreationSystem(LocationFactory locationFactory, EntityManager entityManager, EventManager eventManager) 
            : base(entityManager, eventManager)
        {
            _locationFactory = locationFactory;
            _eventManager.AddListener<CharacterCreationFinishedEvent>(OnCharacterCreationFinished);
        }

        private void OnCharacterCreationFinished(CharacterCreationFinishedEvent obj)
        {
            if (!_locationsCreated)
            {
                CreateLocations();
                _locationsCreated = true;
            }
        }

        public override void Update(float deltaTime)
        {
        }

        private void CreateLocations()
        {
            List<LocationData> locationDataList = LocationDataLoader.LoadLocations(LocationsFilePath);

            foreach (var locationData in locationDataList)
            {
                var location = _locationFactory.CreateLocation(locationData.Name, locationData.Description);
                Console.WriteLine($"{location.GetComponent<LocationComponent>().Name} was created!");
            }
        }

        public override void ProcessEntity(Entity entity, float deltaTime)
        {
            // This system doesn't process entities => Empty
        }
    }
}