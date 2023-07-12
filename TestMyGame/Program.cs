using CoreLibs;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using TestMyGame.Events;
using TestMyGame.Systems;
using TestMyGame.Systems.CharacterCreation;
using TestMyGame.Systems.LocationCreation;
using TestMyGame.Systems.UI;

// Initialize entities, components and events management
var componentRegistry = new ComponentRegistry();
var eventManager = new EventManager();
var entityManager = new EntityManager(componentRegistry, eventManager);

// Initialize our world
var world = new World(entityManager, componentRegistry, eventManager);

// Initialize factory and systems
var characterFactory = new CharacterFactory(entityManager, componentRegistry);
var npcFactory = new NpcFactory(entityManager, componentRegistry);
var characterCreationSystem = new PlayerCharacterCreationSystem(characterFactory, entityManager, eventManager);
var locationFactory = new LocationFactory(entityManager);
var locationCreationSystem = new LocationCreationSystem(locationFactory, entityManager, eventManager);
var locationSelectionSystem = new LocationSelectionSystem(entityManager, eventManager);
var locationActionSystem = new LocationActionSystem(entityManager, eventManager);
var locationActionProcessingSystem = new LocationActionProcessingSystem(entityManager, eventManager);
var navigationSystem = new NavigationSystem(entityManager, eventManager);
var actionSelectionSystem = new ActionSelectionSystem(entityManager, eventManager);
var combatSystem = new CombatSystem(entityManager, eventManager);
var tooltipSystem = new TooltipSystem(entityManager, eventManager);

//--------------------------------------------------------------------------------------------------------------------//

// Add systems to the world
world.AddSystem(characterCreationSystem);
world.AddSystem(locationCreationSystem);
world.AddSystem(locationSelectionSystem);
world.AddSystem(locationActionSystem);
world.AddSystem(locationActionProcessingSystem);
world.AddSystem(navigationSystem);
world.AddSystem(actionSelectionSystem); 
world.AddSystem(combatSystem); 
world.AddSystem(tooltipSystem); 

// Disable the systems that should not be active at the start of the game
locationCreationSystem.Enabled = true;
locationSelectionSystem.Enabled = false;
actionSelectionSystem.Enabled = false;
combatSystem.Enabled = false;

// Game loop
while (true)
{
    var deltaTime = 0.1f; // Just an example, you may want to calculate this properly
    
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;
        eventManager.Emit(new KeypressEvent(key));
    }
    
    world.Update(deltaTime);
}