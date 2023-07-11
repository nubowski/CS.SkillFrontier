namespace CoreLibs.Systems;

public interface ISystem
{
    int Order { get; set; }
    bool Enabled { get; set; }
    void Update(float deltaTime);
}