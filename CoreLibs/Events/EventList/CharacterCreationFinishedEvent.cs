using CoreLibs.Entities;

namespace CoreLibs.Events.EventList;

public class CharacterCreationFinishedEvent : IEvent
{
    public Entity CreatedCharacter { get; }

    public CharacterCreationFinishedEvent(Entity createdCharacter)
    {
        CreatedCharacter = createdCharacter;
    }
}