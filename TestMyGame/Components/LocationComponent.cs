using CoreLibs;

namespace TestMyGame.Components;

public class LocationComponent : IComponent
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Biome { get; set; }
    public int Level { get; set; }
}