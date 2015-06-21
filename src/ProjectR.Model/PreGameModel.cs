using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Model
{
    public class PreGameModel : IPreGameModel
    {
        private readonly Dictionary<EleMastery, int> _masteryMap;
        private readonly IModel _model;

        public PreGameModel(IModel model)
        {
            _model = model;
            _masteryMap = new Dictionary<EleMastery, int>();
            PlayerName = "";
        }

        public int AvailableMasteryPoints { get; set; }
        public string PlayerName { get; set; }
        public bool ShowStats { get; set; }
        public IRaceTemplate RaceTemplate { set; private get; }
        public IArcheType ArcheType { set; private get; }
        public ISkillset Skillset { set; private get; }
        public ISpell SignatureSpell { set; private get; }
        public ISpell NormalAttack { set; private get; }

        public ICharacter Character { get { return GenerateCharacter(); } }

        public void SetMastery(EleMastery mastery, int value)
        {
            _masteryMap[mastery] = value;
        }

        private ICharacter GenerateCharacter()
        {
            var newChar = new Character(PlayerName);
            var newStats = new Stats();

            for (var stat = Stat.HP; stat <= Stat.CHA; ++stat)
            {
                var singleStat = newStats[stat];
                singleStat[StatType.Base] = ArcheType.GetBase(stat);
                singleStat[StatType.Growth] = ArcheType.GetGrowth(stat);
            }

            for (var stat = Stat.PSN; stat <= Stat.DTH; ++stat)
            {
                newStats[stat][StatType.Base] = ArcheType.GetResistance(stat);
            }

            newStats.EVAType = ArcheType.Block ? EVAType.Block : EVAType.Dodge;

            for (var stat = EleMastery.FIR; stat <= EleMastery.LGT; ++stat)
            {
                newStats[stat][StatType.Base] = _masteryMap[stat];
            }

            for (var stat = Stat.HP; stat <= Stat.SIL; ++stat)
            {
                newStats[stat][StatType.Base] *= RaceTemplate.Stats[stat];
                newStats[stat][StatType.Growth] *= RaceTemplate.Stats[stat];
            }

            newStats.XPMultiplier = 1.1d;

            var spells = new List<ISpell>
            {
                NormalAttack,
                _model.SpellFactory.GetSpell("Defend")
            };

            spells.AddRange(Skillset.Spells);
            spells.Add(SignatureSpell);

            newChar.Spells = spells;
            newChar.Race = RaceTemplate.Name;
            newChar.Lore = RaceTemplate.Description;
            newChar.Stats = newStats;
            newChar.SetLvl();
            return newChar;
        }
    }
}