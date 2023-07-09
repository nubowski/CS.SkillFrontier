namespace CoreLibs.Entities;

[Serializable]
public class EntityData
{
    public int Id { get; set; }
    public Dictionary<string, string> Components { get; set; } 
}