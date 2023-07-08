using CoreLibs.Entities;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class HealthSystem : ISystem
{
    private readonly List<Entity> _entities;

    public HealthSystem(List<Entity> entities)
    {
        _entities = entities;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entities)
        {
            if (entity.HasComponent<HealthComponent>())
            {
                var health = entity.GetComponent<HealthComponent>();
                if (health.CurrentHealth <= 0)
                {
                    Console.WriteLine($"The Game is Over!");
                }
            }
        }
    }
}