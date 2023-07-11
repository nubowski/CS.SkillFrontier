using CoreLibs.Entities;
using CoreLibs.Systems;
using TestMyGame.Components;

namespace TestMyGame.Systems.CharacterCreation;

public class CharacterCreationSystem : BaseSystem
{
    private readonly CharacterFactory _characterFactory;
    private readonly EntityManager _entityManager;

    public CharacterCreationSystem(CharacterFactory characterFactory, EntityManager entityManager)
    {
        _characterFactory = characterFactory;
        _entityManager = entityManager;
    }

    public override void Update(float deltaTime)
    {
        Console.WriteLine("Press 'c' to create a new character.");

        var key = Console.ReadKey(true);

        if (key.KeyChar == 'c')
        {
            CreateCharacter();
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

        character.GetComponent<NameComponent>().Name = name;
        character.GetComponent<RaceComponent>().Race = race;
        character.GetComponent<GenderComponent>().Gender = gender;
        
        Console.WriteLine($"{name} the {race} {gender} was created!");
    }
}