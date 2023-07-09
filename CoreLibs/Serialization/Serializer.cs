using System.Text.Json;
using CoreLibs.Entities;

namespace CoreLibs.Serialization;

public class Serializer
{
    public string Serialize(EntityData entityData)
    {
        var json = JsonSerializer.Serialize(entityData);
        return json;
    }
}