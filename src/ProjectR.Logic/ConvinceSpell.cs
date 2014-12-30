using System.Collections.Generic;
using ProjectR.Interfaces;
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
        public double MPCost { get { return 0d; } }
        public void Cast(ICharacter caster, IList<ICharacter> targets)
        {
        }

        public void Cast(ICharacter caster, IList<ICharacter> allies, IList<ICharacter> enemies)
        {
        }

        public void Cast(ICharacter caster, ICharacter target, double decayMod = 1)
        {
        }
    }
}