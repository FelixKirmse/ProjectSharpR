using System;
using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ScriptHelper : IScriptHelper
    {
        public IModel Model { get; set; }

        private readonly Dictionary<ICharacter, double> _damageTakenDictionary;

        public ScriptHelper()
        {
            _damageTakenDictionary = new Dictionary<ICharacter, double>();
        }

        public void ResetAllAfflictions()
        {
            Model.AfflictionFactory.RemoveAllAfflictions();
            // TODO CharAfflMap.Clear
        }

        public IList<IAffliction> GetAfflictions(ICharacter character)
        {
            return new IAffliction[0]; // TODO get affliction for character
        }

        public void DealDamage(ICharacter target, double damage)
        {
            if (!_damageTakenDictionary.ContainsKey(target))
            {
                _damageTakenDictionary.Add(target, Math.Max(0d, damage));
                return;
            }

            _damageTakenDictionary[target] += Math.Max(0d, damage);
        }

        public void Heal(ICharacter target, double healing)
        {
            if (!_damageTakenDictionary.ContainsKey(target))
            {
                _damageTakenDictionary.Add(target, -Math.Max(0d, healing));
                return;
            }

            _damageTakenDictionary[target] -= Math.Max(0d, healing);
        }

        public void TryToApplyDebuff(DebuffResistance type, int applyChance)
        {
            throw new System.NotImplementedException();
        }

        public double GetDamageTaken(ICharacter character)
        {
            if (!_damageTakenDictionary.ContainsKey(character))
            {
                return 0d;
            }

            return _damageTakenDictionary[character];
        }
    }
}