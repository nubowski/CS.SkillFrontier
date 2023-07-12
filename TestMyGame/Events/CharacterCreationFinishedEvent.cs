using CoreLibs.Entities;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class CharacterCreationFinishedEvent : IEvent
{
    public Entity CreatedCharacter { get; }

    public CharacterCreationFinishedEvent(Entity createdCharacter)
    {
        CreatedCharacter = createdCharacter;
    }
}