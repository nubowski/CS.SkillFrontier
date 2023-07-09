using System.Text.Json;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Serialization;
using CoreLibs.Systems;
using TestMyGame.Components;
using TestMyGame.Systems;

// Create component registry instance
var componentRegistry = new ComponentRegistry();
var eventManager = new EventManager();

// Create entities and systems
var entityManager = new EntityManager(componentRegistry, eventManager);
var systems = new List<ISystem>();

// Create an entity and add components
// Temp rnd damage for the showcase
Random rnd = new Random();
var playerEntity = entityManager.CreateEntity();
playerEntity.AddComponent(new HealthComponent {CurrentHealth = 100, MaxHealth = 100});
playerEntity.AddComponent(new DamageComponent { Damage = rnd.Next(1, 11) });

var enemyEntity = entityManager.CreateEntity();
enemyEntity.AddComponent(new HealthComponent {CurrentHealth = 100, MaxHealth = 100});
enemyEntity.AddComponent(new DamageComponent { Damage = rnd.Next(1, 11) });


// Create systems and add to the system list (HUB like)
var damageSystem = new DamageSystem(componentRegistry, eventManager);
systems.Add(damageSystem);

var healthSystem = new HealthSystem(componentRegistry, eventManager, entityManager);
systems.Add(healthSystem);

// Create entity manager and emit to EntityDestroyedEvent
eventManager.AddListener<EntityDestroyedEvent>(entityManager.OnEntityDestroy);

// Sorting systems on its order
systems = systems.OrderBy(system => system.Order).ToList();

// The main game loop
while (true)
{
    
    // Use your existing components and entities
    var originalEntity = entityManager.CreateEntity();
    originalEntity.AddComponent(new HealthComponent {CurrentHealth = 100, MaxHealth = 100});
    originalEntity.AddComponent(new DamageComponent { Damage = 10 });

// Convert the entity to EntityData
    var entityData = originalEntity.ToEntityData();

// Serialize and deserialize the EntityData
    var serializer = new Serializer();
    var deserializer = new Deserializer();
    var serializedEntityData = serializer.Serialize(entityData);
    var deserializedEntityData = deserializer.Deserialize(serializedEntityData);

// Print out the serialized and deserialized EntityData
    Console.WriteLine("Serialized EntityData: " + serializedEntityData);
    Console.WriteLine("Deserialized EntityData: " + deserializedEntityData.ToString());  // Assuming you have a suitable ToString method
    
    foreach (var system in systems)
    {
        system.Update(1); // Temp pass the deltaTime as 1
    }
    
    // Check if playerEntity or enemyEntity exists and has HealthComponent
    if (playerEntity != null && playerEntity.HasComponent<HealthComponent>())
    {
        var playerHealth = playerEntity.GetComponent<HealthComponent>();
        Console.WriteLine($"Player health: {playerHealth.CurrentHealth}");
        if (playerHealth.CurrentHealth <= 0)
        {
            Console.WriteLine($"You have 0 health points!");
            break;
        }
    }
    
    if (enemyEntity != null && enemyEntity.HasComponent<HealthComponent>())
    {
        var enemyHealth = enemyEntity.GetComponent<HealthComponent>();
        Console.WriteLine($"Enemy health: {enemyHealth.CurrentHealth}");
    }
    
    // pause for input
    Console.ReadKey();
}
