using System.Text.Json;
using CoreLibs.Entities;

namespace CoreLibs.Serialization;

public class Deserializer
{
    public EntityData Deserialize(string json)
    {
        var entityData = JsonSerializer.Deserialize<EntityData>(json);

        if (entityData == null)
        {
            throw new InvalidOperationException("Failed to deserialize entity data.");
        }

        return entityData;
    }
}