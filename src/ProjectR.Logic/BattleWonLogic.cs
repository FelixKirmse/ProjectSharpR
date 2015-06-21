using System.Linq;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class BattleWonLogic : LogicState
    {
        private bool _battleOver;

        public bool IsBattleOver
        {
            get
            {
                var result = _battleOver;
                if (result)
                {
                    _battleOver = false;
                }
                return result;
            }
        }

        public override void Run()
        {
            var battleModel = Model.BattleModel;
            var mobPack = battleModel.CurrentMobPack;
            var party = Model.Party;

            double xpAwarded = mobPack.XPReward;

            if (battleModel.Enemies.Count == 1)
            {
                xpAwarded *= mobPack.GetConvertBonus(battleModel.Enemies.First());
            }

            foreach (var character in party.FrontRow)
            {
                character.Stats.ReduceBuffEffectiveness(10);
                character.UseMP(-50d);
            }

            foreach (var character in party.BackSeat)
            {
                character.Stats.ReduceBuffEffectiveness(10);
                character.UseMP(-50d);
            }

            party.AddExperience((int) xpAwarded);
            Model.Statistics.AddToStatistic(Statistic.ExperienceEarned, (uint) xpAwarded);
            Model.CommitChanges();

            do
            {
                Input.Update();
            } while (!Input.Action(Actions.Confirm));

            _battleOver = true;
        }
    }
}