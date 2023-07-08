using CoreLibs.Entities;
using CoreLibs.Systems;
using TestMyGame.Components;
using TestMyGame.Systems;

// Create entities and systems
var entities = new List<Entity>();
var systems = new List<ISystem>();

// Create an entity and add components
var playerEntity = new Entity();
playerEntity.AddComponent(new HealthComponent {CurrentHealth = 100, MaxHealth = 100});

entities.Add(playerEntity);

// Create systems and add to the system list (HUB like)
var healthSystem = new HealthSystem(entities);
systems.Add(healthSystem);

// The main game loop
while (true)
{
    foreach (var system in systems)
    {
        system.Update(1); // Temp pass the deltaTime as 1
    }
    
    // Just primitive game loop for checking if all is working
    var playerHealth = playerEntity.GetComponent<HealthComponent>();
    Console.WriteLine($"Player health: {playerHealth.CurrentHealth}");

    if (playerHealth.CurrentHealth <= 0)
    {
        Console.WriteLine($"You have 0 health points!");
        break;
    }
    
    // pause for input
    Console.ReadKey();
    
    // some damage imitation
    playerHealth.CurrentHealth -= 10;
}