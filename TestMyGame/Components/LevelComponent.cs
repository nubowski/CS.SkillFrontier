using CoreLibs;

namespace TestMyGame.Components;

public class LevelComponent : IComponent
{
    public int Level { get; set; }

    public LevelComponent()
    {
        Level = 1;
    }
}