using CoreLibs;
using CoreLibs.Entities;
using CoreLibs.Events;
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

//--------------------------------------------------------------------------------------------------------------------//

// Add systems to the world
world.AddSystem(characterCreationSystem);

// Game loop
while (true)
{
    var deltaTime = 0.1f; // Just an example, you may want to calculate this properly
    world.Update(deltaTime);
}