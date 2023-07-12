﻿using CoreLibs.Components;

namespace TestMyGame.Components.Stimul;

public class MindAttributeComponent : IComponent
{
    public int Mind { get; set; }

    public MindAttributeComponent()
    {
        Mind = 1;
    }
}