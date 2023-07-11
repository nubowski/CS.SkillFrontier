using CoreLibs;
using CoreLibs.Entities;
using CoreLibs.Events;
using TestMyGame.Systems;
using TestMyGame.Systems.CharacterCreation;

// Initialize entities, components and events management
var componentRegistry = new ComponentRegistry();
var eventManager = new EventManager();
var entityManager = new EntityManager(componentRegistry, eventManager);

// Initialize our world
var world = new World(entityManager, componentRegistry, eventManager);

// Initialize factory and systems
var characterFactory = new CharacterFactory(entityManager, componentRegistry);
var characterCreationSystem = new CharacterCreationSystem(characterFactory, entityManager);
var locationSelectionSystem = new LocationSelectionSystem(entityManager); // Add this
var actionSelectionSystem = new ActionSelectionSystem(entityManager); // Add this
var combatSystem = new CombatSystem(entityManager); // Add this

//--------------------------------------------------------------------------------------------------------------------//

// Add systems to the world
world.AddSystem(characterCreationSystem);
world.AddSystem(locationSelectionSystem); // Add this
world.AddSystem(actionSelectionSystem); // Add this
world.AddSystem(combatSystem); // Add this

// Disable the systems that should not be active at the start of the game
locationSelectionSystem.Enabled = false;
actionSelectionSystem.Enabled = false;
combatSystem.Enabled = false;

// Game loop
while (true)
{
    var deltaTime = 0.1f; // Just an example, you may want to calculate this properly
    world.Update(deltaTime);
}