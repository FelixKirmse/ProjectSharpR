using System;
using System.Collections.Generic;
using System.IO;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Model
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IModel _model;
        private readonly List<string> _names;

        private readonly Dictionary<string, List<IAffliction>> _passives;
        private readonly Dictionary<string, ICharacter> _specialChars;
        private readonly ISpellFactory _spellFactory;

        public CharacterFactory(IModel model)
        {
            _model = model;
            _spellFactory = _model.SpellFactory;
            _names = new List<string>(File.ReadAllLines("content/etc/Names.txt"));
            BossList = new List<string>();
            _specialChars = new Dictionary<string, ICharacter>();
            _passives = new Dictionary<string, List<IAffliction>>();
        }

        public IList<string> BossList { get; private set; }

        public void LoadCharacters()
        {
            throw new NotImplementedException();
        }

        public ICharacter CreateRandomCharacter(int level = 1, IRaceTemplate race = null)
        {
            var newChar = new Character(GetRandomName());
            SharedGenerationFunction(newChar, level, race);
            return newChar;
        }

        public ICharacter CreateRandomEnemy(int level = 1)
        {
            var newChar = new Character(GetRandomName());
            SharedGenerationFunction(newChar, level);
            return newChar;
        }

        public ICharacter GetSpecialCharacter(string name)
        {
            return _specialChars[name].Clone();
        }

        public IList<IAffliction> GetPassives(ICharacter character)
        {
            var passives = new List<IAffliction>();

            passives.AddRange(_passives[character.Name]);
            passives.AddRange(_model.RaceFactory.GetPassivesForRace(character.Race));

            return passives;
        }

        private string GetRandomName()
        {
            return _names[RHelper.Roll(_names.Count)];
        }

        public void SharedGenerationFunction(ICharacter newChar, int level, IRaceTemplate race = null)
        {
            IRaceTemplate rTemplate = race ?? _model.RaceFactory.GetRandomTemplate();
            IStats randomStats = Stats.GetRandomBaseStats();
            newChar.Race = rTemplate.Name;
            newChar.Lore = rTemplate.Description;
            ApplyRaceTemplate(rTemplate, randomStats);
            newChar.Stats = randomStats;
            newChar.LvlUp(_model.Party.Experience);
            var spells = new List<ISpell> { _spellFactory.GetSpell("Attack"), _spellFactory.GetSpell("Defend") };
            int spellCount = RHelper.Roll(2, 5);
            for (int i = 0; i < spellCount; ++i)
            {
                ISpell spell;

                do
                {
                    spell = _spellFactory.GetRandomSpell();
                } while (spells.Contains(spell));

                spells.Add(spell);
            }
            newChar.Spells = spells;
        }

        private static void ApplyRaceTemplate(IRaceTemplate rTemplate, IStats stats)
        {
            for (var stat = Stat.HP; stat <= Stat.SIL; ++stat)
            {
                stats[stat][StatType.Base] *= rTemplate.Stats[stat];
                stats[stat][StatType.Growth] *= rTemplate.Stats[stat];
            }
        }
    }
}