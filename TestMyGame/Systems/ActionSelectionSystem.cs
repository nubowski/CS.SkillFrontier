using CoreLibs.Entities;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class ActionSelectionSystem : BaseSystem
{
    public ActionSelectionSystem(EntityManager entityManager) : base(entityManager)
    {
        _entityManager = entityManager;
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(CharacterComponent)
        });
    }
    
    public override void Update(float deltaTime)
    {
        // handle action selection here
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}