using CoreLibs.Core;
using CoreLibs.Events;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class ActionSelectionSystem : BaseSystem
{
    public ActionSelectionSystem(EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
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