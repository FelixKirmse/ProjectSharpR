using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Logic
{
    public class ConvinceSpell : ISpell
    {
        public string Name { get { return "Convert"; } }
        public TargetType TargetType { get {return TargetType.Single;} }
        public string Description { get { return ""; } }
        public bool IsSupportSpell { get { return false; } }
        public double Delay { get { return .5d; } }
        public IList<EleMastery> Masteries { get { return new EleMastery[0]; } }
        public SpellType SpellType { get { return SpellType.Pure; } }
        public IScriptHelper ScriptHelper { get; set; }

        public double DamageCalculation(ICharacter attacker, ICharacter defender, double specialModifier = 1)
        {
            return 0d;
        }

        public double GetMPCost(ICharacter caster)
        {
            return 0d;
        }

        public void ForceReload()
        {
        }
    }
}