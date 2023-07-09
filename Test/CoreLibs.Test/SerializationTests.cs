using System;
using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Serialization;
using TestMyGame.Components;
using Xunit;
using Xunit.Abstractions;

namespace CoreLibs.Test;

public class SerializationTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Serializer _serializer = new();
    private readonly Deserializer _deserializer = new();
    private readonly ComponentRegistry _componentRegistry = new();
    private readonly EventManager _eventManager = new();

    public SerializationTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CanSerializeAndDeserializeEntity()
    {
        var entityManager = new EntityManager(_componentRegistry, _eventManager);
    
        var originalEntity = entityManager.CreateEntity();
        originalEntity.AddComponent(new HealthComponent {CurrentHealth = 100, MaxHealth = 100});
        originalEntity.AddComponent(new DamageComponent { Damage = 10 });

        var entityData = originalEntity.ToEntityData();

        var serializedEntity = _serializer.Serialize(entityData);
        _testOutputHelper.WriteLine($"Serialized entity: {serializedEntity}");

        var deserializedEntityData = _deserializer.Deserialize(serializedEntity);
        _testOutputHelper.WriteLine($"Deserialized entity data: {deserializedEntityData}");

        Assert.NotNull(deserializedEntityData); // Add this to handle the case when Deserialize returns null

        var restoredEntity = entityManager.CreateEntityFromData(deserializedEntityData!); // Unwrapping null-checked EntityData 

        var restoredHealthComponent = restoredEntity.GetComponent<HealthComponent>();
        _testOutputHelper.WriteLine($"Restored Health Component: {restoredHealthComponent}");

        var originalHealthComponent = originalEntity.GetComponent<HealthComponent>();

        Assert.Equal(originalEntity.Id, restoredEntity.Id);
        Assert.Equal(originalHealthComponent.CurrentHealth, restoredHealthComponent.CurrentHealth);
        Assert.Equal(originalHealthComponent.MaxHealth, restoredHealthComponent.MaxHealth);

        var restoredDamageComponent = restoredEntity.GetComponent<DamageComponent>();
        var originalDamageComponent = originalEntity.GetComponent<DamageComponent>();

        Assert.Equal(originalDamageComponent.Damage, restoredDamageComponent.Damage);
    }

}