using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Logic
{
    public class ConvinceLogic : LogicState
    {
        private bool _success;

        public override void Activate()
        {
            var attacker = Model.BattleModel.CurrentAttacker;
            var target = Model.BattleModel.Enemies[0];

            var attackerCHA = attacker.Stats.GetTotalStat(BaseStat.CHA);
            var targetCHA = target.Stats.GetTotalStat(BaseStat.CHA);

            var targetInfo = new TargetInfo { Spell = new ConvinceSpell(), Target = target };
            Model.BattleModel.TargetInfo = targetInfo;

            _success = attackerCHA * attacker.HPPercentage > targetCHA * 3 * target.HPPercentage;

            target.IsMarked = _success;
        }

        public override void Run()
        {
            var target = Model.BattleModel.Enemies[0];
            Model.CommitChanges();

            do
            {
                Input.Update();
            } while (!Input.Action(Actions.Confirm));

            target.IsMarked = false;

            if (!_success)
            {
                Master.SetCurrentState((int) BattleMenuState.Execute);
                return;
            }

            Master.SetCurrentState((int) BattleMenuState.SelectAction);
            Model.BattleModel.CurrentBattleState = BattleState.BattleWon;
            Model.Party.AddCharacter(target);
            Model.Statistics.AddToStatistic(Statistic.EnemiesJoined, 1);
        }
    }
}