using System.ComponentModel;
using IComponent = CoreLibs.Core.IComponent;

namespace TestMyGame.Components;

public class PositionComponent : CoreLibs.Core.IComponent
{
    public int CurrentLocationId { get; set; }
}