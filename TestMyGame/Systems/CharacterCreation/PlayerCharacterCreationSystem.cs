﻿using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Events.EventList;
using CoreLibs.Systems;
using TestMyGame.Components;
using TestMyGame.Events;

namespace TestMyGame.Systems.CharacterCreation;

public class PlayerCharacterCreationSystem : BaseSystem
{
    private readonly CharacterFactory _characterFactory;
    public bool _playerCharacterCreated = false;

    public PlayerCharacterCreationSystem(CharacterFactory characterFactory, EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
    {
        _characterFactory = characterFactory;
        ComponentFilter.MustHaveComponents.Add(typeof(NameComponent));
        ComponentFilter.MustHaveComponents.Add(typeof(RaceComponent));
        ComponentFilter.MustHaveComponents.Add(typeof(GenderComponent));
    }

    public override void Update(float deltaTime)
    {
        if (!_playerCharacterCreated)
        {
            Console.WriteLine("Press 'c' to create a new character.");

            var key = Console.ReadKey(true);

            if (key.KeyChar == 'c')
            {
                CreateCharacter();
                _playerCharacterCreated = true;
            }
        }
    }

    private void CreateCharacter()
    {
        Console.Write("Enter character name: ");
        string name = Console.ReadLine();

        Console.Write("Select race (1 - Human, 2 - Orc): ");
        int raceChoice = Convert.ToInt32(Console.ReadLine());
        RaceComponent.RaceType race = raceChoice == 1 ? RaceComponent.RaceType.Human : RaceComponent.RaceType.Orc;

        Console.Write("Select gender (1 - Male, 2 - Female): ");
        int genderChoice = Convert.ToInt32(Console.ReadLine());
        GenderComponent.GenderType gender = genderChoice == 1 ? GenderComponent.GenderType.Male : GenderComponent.GenderType.Female;

        var character = _characterFactory.CreateCharacter();

        character.GetComponent<RaceComponent>().Race = race;
        character.GetComponent<GenderComponent>().Gender = gender;

        character.AddComponent(new NameComponent(name));
        character.AddComponent(new PlayerComponent());
        character.AddComponent(new ExperienceComponent());
        
        Console.WriteLine($"{name} the {race} {gender} was created!");
        _eventManager.Emit(new CharacterCreationFinishedEvent(character));
        _eventManager.Emit(new StatsUpdatedEvent(character));
    }

    public override void ProcessEntity(Entity entity, float deltaTime)
    {
        // This system doesn't process entities => Empty
    }
}