﻿using CoreLibs.Core;

namespace TestMyGame.Components.Stimul;

public class AgilityAttributeComponent : IComponent
{
    public int Agility { get; set; }

    public AgilityAttributeComponent()
    {
        Agility = 1;
    }
}