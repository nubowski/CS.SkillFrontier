namespace CoreLibs.Systems;

public interface ISystem
{
    int Order { get; set; }
    void Update(float deltaTime);
}