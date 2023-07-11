﻿using CoreLibs;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using TestMyGame.Systems;
using TestMyGame.Systems.CharacterCreation;
using TestMyGame.Systems.UI;

// Initialize entities, components and events management
var componentRegistry = new ComponentRegistry();
var eventManager = new EventManager();
var entityManager = new EntityManager(componentRegistry, eventManager);

// Initialize our world
var world = new World(entityManager, componentRegistry, eventManager);

// Initialize factory and systems
var characterFactory = new CharacterFactory(entityManager, componentRegistry);
var characterCreationSystem = new CharacterCreationSystem(characterFactory, entityManager, eventManager);
var locationSelectionSystem = new LocationSelectionSystem(entityManager, eventManager);
var actionSelectionSystem = new ActionSelectionSystem(entityManager, eventManager);
var combatSystem = new CombatSystem(entityManager, eventManager);
var tooltipSystem = new TooltipSystem(entityManager, eventManager);

//--------------------------------------------------------------------------------------------------------------------//

// Add systems to the world
world.AddSystem(characterCreationSystem);
world.AddSystem(locationSelectionSystem); 
world.AddSystem(actionSelectionSystem); 
world.AddSystem(combatSystem); 
world.AddSystem(tooltipSystem); 

// Disable the systems that should not be active at the start of the game
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