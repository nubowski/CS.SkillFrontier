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
}