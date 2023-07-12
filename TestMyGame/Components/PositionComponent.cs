using System.ComponentModel;
using IComponent = CoreLibs.Components.IComponent;

namespace TestMyGame.Components;

public class PositionComponent : IComponent
{
    public int CurrentLocationId { get; set; }
}