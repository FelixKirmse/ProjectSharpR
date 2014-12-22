using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class Spell : ISpell
    {
        public TargetType TargetType { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsSupportSpell { get; private set; }
        public double Delay { get; private set; }
        public IList<EleMastery> Masteries { get; private set; }
        public SpellType SpellType { get; private set; }

        private readonly IModel _model;

        public Spell(IModel model, string fileName)
        {
            _model = model;
        }

        public double DamageCalculation(ICharacter attacker, ICharacter defender, double specialModifier = 1)
        {
            throw new System.NotImplementedException();
        }

        public double GetMPCost(ICharacter caster)
        {
            throw new System.NotImplementedException();
        }

        public void ForceReload()
        {
            throw new System.NotImplementedException();
        }
    }
}