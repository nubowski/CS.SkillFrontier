namespace CoreLibs.Systems;

public interface ISystem
{
    int Order { get; }
    void Update(float deltaTime);
}