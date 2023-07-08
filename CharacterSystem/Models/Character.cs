using CoreLibs.Interfaces;
using CoreLibs.Utilities;

namespace CharacterSystem.Models;

public class Character : IIdentifiable, INameable, IDescribable
{
    public Guid Id { get; } = IdGenerator.NewId();
    public string Name { get; set; }
    public string Description { get; set; }
    
    // S.T.I.M.U.L. Attributes
    public int Strength { get; set; }
    public int Toughness { get; set; }
    public int Intelligence { get; set; }
    public int Mind { get; set; }
    public int Luck { get; set; }
    public int Agility { get; set; }
}