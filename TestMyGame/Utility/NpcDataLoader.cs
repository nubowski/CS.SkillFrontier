using Newtonsoft.Json;

namespace TestMyGame.Utility
{
    public static class NpcDataLoader
    {
        public static List<NpcData> LoadNpc(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<NpcData>>(json) ?? throw new InvalidOperationException("No NPC Data Provided");
        }
    }

    public class NpcData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Race { get; set; }
        public int Weight { get; set; }
        public List<string> Biomes { get; set; }
        public List<string> CombatPhrases { get; set; }
    }
}