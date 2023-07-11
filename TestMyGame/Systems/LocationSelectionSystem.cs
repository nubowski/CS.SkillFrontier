using CoreLibs.Entities;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class LocationSelectionSystem : BaseSystem
{
    public LocationSelectionSystem(EntityManager entityManager) : base(entityManager)
    {
        _entityManager = entityManager;
        
        ComponentFilter.MustHaveComponents.AddRange(new Type[]
        {
            typeof(CharacterComponent),
            typeof(PlayerComponent)
        });
    }
    
    public override void Update(float deltaTime)
    {
        // handle location selection here
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        throw new NotImplementedException();
    }
}