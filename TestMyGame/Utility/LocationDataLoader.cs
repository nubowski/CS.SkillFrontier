using Newtonsoft.Json;

namespace TestMyGame.Utility;

public static class LocationDataLoader
{
    public static List<LocationData> LoadLocations(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<LocationData>>(json) ?? throw new InvalidOperationException("No Location Data Provided");
    }
}

public class LocationData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Biome { get; set; }
    public int Level { get; set; }
    public List<NpcPoolItem> NpcPool { get; set; }
}

public class NpcPoolItem
{
    public string Type { get; set; }
    public string Value { get; set; }
    public int Weight { get; set; }
    public string Description { get; set; }
}