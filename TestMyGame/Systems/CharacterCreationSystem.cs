using CoreLibs;
using CoreLibs.Utilities;
using TestMyGame.Components;

namespace TestMyGame.Systems;

public class CharacterCreationSystem : BaseSystem
{
    private Filter _filter;
    
    public override void OnAwake()
    {
        this._filter = this.World.Filter.Add<CharacterCreationRequestComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            Console.Write("Enter character name: ");
            string name = Console.ReadLine();

            Logger.Game("Select race (1 - Human, 2 - Orc): ");
            int raceChoice = Convert.ToInt32(Console.ReadLine());
            RaceComponent.RaceType race = raceChoice == 1 ? RaceComponent.RaceType.Human : RaceComponent.RaceType.Orc;

            Logger.Game("Select gender (1 - Male, 2 - Female): ");
            int genderChoice = Convert.ToInt32(Console.ReadLine());
            GenderComponent.GenderType gender = genderChoice == 1 ? GenderComponent.GenderType.Male : GenderComponent.GenderType.Female;

            World.EntityManager.RemoveComponent<CharacterCreationRequestComponent>(entity);
            World.EntityManager.AddComponent(entity, new NameComponent(name));
            World.EntityManager.AddComponent(entity, new RaceComponent() { Race = race });
            World.EntityManager.AddComponent(entity, new GenderComponent() { Gender = gender });
            World.EntityManager.AddComponent(entity, new PlayerComponent());
            World.EntityManager.AddComponent(entity, new ExperienceComponent());

            Logger.Game($"{name} the {race} {gender} was created!");
        }
    }
}