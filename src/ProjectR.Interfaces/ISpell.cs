using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces
{
    public interface ISpell : INameHolder
    {
        TargetType TargetType { get; }
        string Description { get; }
        bool IsSupportSpell { get; }
        double Delay { get; }
        IList<EleMastery> Masteries { get; }
        SpellType SpellType { get; }
        IScriptHelper ScriptHelper { get; set; }

        double SpellEffect(ICharacter attacker, ICharacter defender, double specialModifier = 1d);
        double GetMPCost(ICharacter caster);
        void ForceReload();
    }
}