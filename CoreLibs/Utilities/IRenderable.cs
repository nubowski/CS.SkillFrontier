namespace AsciiRenderer.Interfaces;

public interface IRenderable
{
    // char matrix to render boxes (grid layout)
    char[][] GetAsciiRepresentation();
}