using CoreLibs.Components;

namespace TestMyGame.Components;

public class CombatPhrasesComponent : IComponent
{
    public CombatPhrasesComponent(List<string> combatPhrases)
    {
        CombatPhrases = combatPhrases;
    }

    public List<string> CombatPhrases { get; set; }
}