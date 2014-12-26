using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Logic;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Logic
{
    public class CharacterSpellSelect : ICharacterSpellSelect
    {
        public ITargetInfo SelectSpell(ICharacter character, IBattleModel battleModel, bool isEnemy)
        {
            // TODO Check if Boss has Rotation
            var targetInfo = new TargetInfo();
            var lowHP = character.CurrentHP / character.Stats.GetTotalStat(BaseStat.HP) <= .3d;
            var lowMP = character.CurrentMP <= 75d;
            var silenced = character.IsSilenced;
            var defendAvailable = silenced || lowHP || lowMP;
            var spellSelectCount = 0;
            var initialSpellIndex = defendAvailable ? 1 : 2;
            var spellList = character.Spells;

            do
            {
                if (spellList.Count == 1)
                {
                    targetInfo.Spell = spellList[0];
                    break;
                }

                ++spellSelectCount;
                if (spellSelectCount == 10)
                {
                    initialSpellIndex = 0;
                }

                targetInfo.Spell = spellList[RHelper.Roll(silenced ? 0 : initialSpellIndex, silenced ? 1 : spellList.Count - 1)];
            } while (targetInfo.Spell.GetMPCost(character) >= character.CurrentMP + 1f);

            targetInfo.Target = null;
            var targetType = targetInfo.Spell.TargetType;
            if (targetType == TargetType.Allies || targetType == TargetType.Enemies)
            {
                return targetInfo;
            }

            if (targetType == TargetType.Myself)
            {
                targetInfo.Target = character;
                return targetInfo;
            }

            var enemies = battleModel.Enemies;
            var frontRow = battleModel.FrontRow;

            if (targetInfo.Spell.IsSupportSpell)
            {
                var rollMax = isEnemy ? enemies.Count - 1 : frontRow.Count - 1;
                do
                {
                    targetInfo.Target = isEnemy ? enemies[RHelper.Roll(rollMax)] : frontRow[RHelper.Roll(rollMax)];
                } while (targetInfo.Target.IsDead);

                return targetInfo;
            }

            targetInfo.Target = isEnemy ? GetTarget(frontRow) : GetTarget(enemies);
            return targetInfo;
        }

        private static ICharacter GetTarget(IList<ICharacter> characters)
        {
            /********************************
             * 60% to attack main tank      *
             * 30% to attack secondary tank *
             * 5% each to attack back row   *
             ********************************/

            ICharacter target = null;
            var size = characters.Count;

            do
            {
                var targetRoll = RHelper.Roll(99);
                target = characters[targetRoll < 60 || size == 1
                    ? 0
                    : targetRoll < 90 || size == 2
                        ? 1
                        : targetRoll < 95 || size == 3
                            ? 2
                            : 3];
            } while (target.IsDead);
            return target;
        }
    }
}