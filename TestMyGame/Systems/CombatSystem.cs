using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class CombatSystem : BaseSystem
{
    public CombatSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _entityManager = entityManager;
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(CharacterComponent),
            typeof(HealthComponent),
            typeof(AttackComponent)
        });
    }
    
    public override void Update(float deltaTime)
    {
        // combat goes here
    }
    
    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}