namespace AsciiRenderer.Interfaces;

public interface IAsciiRenderer
{
    void Clear();
    void Draw(char renderableComponentCharacter, int renderableComponentX, int renderableComponentY);
}