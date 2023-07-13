using CoreLibs.Core;

namespace TestMyGame.Components;

public class RaceComponent : IComponent
{
    public enum RaceType
    {
        Human,
        Orc,
        Beast,
        Plant,
        Goblin,
        Troll,
        Insect,
        Elf,
        Elemental,
        Vampire,
        Lich,
        Ghost,
        Dragon
    }

    public RaceType Race { get; set; }
}