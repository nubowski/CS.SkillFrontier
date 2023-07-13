using CoreLibs;
using CoreLibs.Utilities;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class PlayerCharacterCreationRequestSystem : BaseSystem
{
    public override void OnAwake()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
        Logger.Game("Press 'C' to create a new character.");
        var key = Console.ReadKey(true);
        if (key.KeyChar == 'C')
        {
            var entity = World.EntityManager.CreateEntity();
            World.EntityManager.AddComponent(entity, new CharacterCreationRequestComponent());
        }
    }
}