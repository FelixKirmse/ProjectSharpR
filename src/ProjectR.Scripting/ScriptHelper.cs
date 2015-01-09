using System;
using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public class ScriptHelper : IScriptHelper
    {
        public IModel Model { get; set; }

        private readonly Dictionary<ICharacter, double> _damageTakenDictionary;
        private readonly Dictionary<ICharacter, Dictionary<string, double>> _characterVariables;
        private readonly Dictionary<ICharacter, List<IAffliction>> _charAfflDictionary; 

        public ScriptHelper()
        {
            _damageTakenDictionary = new Dictionary<ICharacter, double>();
            _characterVariables = new Dictionary<ICharacter, Dictionary<string, double>>();
            _charAfflDictionary = new Dictionary<ICharacter, List<IAffliction>>();
        }

        public void ResetAllAfflictions()
        {
            Model.AfflictionFactory.RemoveAllAfflictions();
            _charAfflDictionary.Clear();
        }

        public IList<IAffliction> GetAfflictions(ICharacter character)
        {
            if (!_charAfflDictionary.ContainsKey(character))
            {
                return new IAffliction[0]; 
            }

            return _charAfflDictionary[character];
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

        public void TryToApplyDebuff(ICharacter target, DebuffResistance type, int applyChance)
        {
            var result = new BoolConsolidator();
            target.FireApplyingDebuffEvent(result);
            if (!result.Result())
            {
                return;
            }

            if (!target.Stats.TryToApplyDebuf(type, applyChance))
            {
                return;
            }

            IAffliction affl = null;
            var afflFac = Model.AfflictionFactory;

            switch (type)
            {
                case DebuffResistance.PSN:
                    affl = afflFac.GetAffliction("Poison");
                    target.AddAffliction("PSN");
                    break;

                case DebuffResistance.PAR:
                    affl = afflFac.GetAffliction("Paralyze");
                    target.AddAffliction("PAR");
                    break;

                case DebuffResistance.DTH:
                    affl = afflFac.GetAffliction("InstaDeath");
                    target.AddAffliction("DTH");
                    break;

                case DebuffResistance.SIL:
                    affl = afflFac.GetAffliction("Silence");
                    target.AddAffliction("SIL");
                    break;
            }

            if (affl == null)
            {
                return;
            }

            affl.AttachTo(target);
            _charAfflDictionary.GetOrCreate(target).Add(affl);   
        }

        public double GetDamageTaken(ICharacter character)
        {
            if (!_damageTakenDictionary.ContainsKey(character))
            {
                return 0d;
            }

            return _damageTakenDictionary[character];
        }

        public bool IsEnemy(ICharacter target)
        {
            return Model.BattleModel.CharacterIsEnemy(target);
        }

        public double GetVar(ICharacter target, string varName)
        {
            if (!_characterVariables.ContainsKey(target))
            {
                _characterVariables.Add(target, new Dictionary<string, double> { { varName, 0d }});
            }

            var vars = _characterVariables[target];

            if (!vars.ContainsKey(varName))
            {
                vars.Add(varName, 0d);
            }

            return vars[varName];
        }

        public void ResetDamageTaken()
        {
            _damageTakenDictionary.Clear();
        }

        public void SetVar(ICharacter target, string varName, double value)
        {
            _characterVariables.GetOrCreate(target).SetOrInsert(varName, value);
        }

        public void ApplyAffliction(ICharacter target, string affliction)
        {
            var affl = Model.AfflictionFactory.GetAffliction(affliction);
            var result = new BoolConsolidator();

            if (affl.Type == AfflictionType.Buff)
            {
                target.FireApplyingBuffEvent(result);
            }
            else
            {
                target.FireApplyingDebuffEvent(result);
            }

            if (!result.Result())
            {
                return;
            }

            affl.AttachTo(target);
            target.AddAffliction(affliction);
            _charAfflDictionary.GetOrCreate(target).Add(affl);
        }

        public IEnumerable<ICharacter> GetCasterParty()
        {
            var battleModel = Model.BattleModel;
            return battleModel.AttackerIsEnemy ? battleModel.Enemies : battleModel.FrontRow;
        }

        public void RemoveDebuffs(ICharacter target)
        {
            if (!_charAfflDictionary.ContainsKey(target))
            {
                return;
            }

            foreach (var affliction in _charAfflDictionary[target].Where(x => x.Type == AfflictionType.Debuff))
            {
                affliction.RemoveFrom(target);
            }

            target.FireRemovingDebuffs();
        }

        public IEnumerable<ICharacter> GetCasterReserveParty()
        {
            if (Model.BattleModel.AttackerIsEnemy)
            {
                return new ICharacter[0];
            }

            return Model.Party.Reserve;
        }
    }
}