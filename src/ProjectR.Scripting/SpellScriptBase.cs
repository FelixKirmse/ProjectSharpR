using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    public abstract class SpellScriptBase : SpellBase
    {
        protected void DealDamage(ICharacter target, double damage)
        {
            ScriptHelper.DealDamage(target, damage);
        }

        protected void Heal(ICharacter target, double healing)
        {
            ScriptHelper.Heal(target, healing);
        }

        protected void TryToApplyDebuff(DebuffResistance type, int applyChance)
        {
            ScriptHelper.TryToApplyDebuff(type, applyChance);
        }

        protected void BuffStat(ICharacter target, Stat stat, double buffMod)
        {
            target.BuffStat(stat, buffMod);
        }

        protected void BuffAllStats(ICharacter target, double buffMod)
        {
            for (var stat = Stat.AD; stat < Stat.Count; ++stat)
            {
                BuffStat(target, stat, buffMod);
            }
        }

        protected void BuffBaseStats(ICharacter target, double buffMod)
        {
            for (var stat = Stat.AD; stat <= Stat.CHA; ++stat)
            {
                BuffStat(target, stat, buffMod);
            }
        }

        protected void BuffMasteryStats(ICharacter target, double buffMod)
        {
            for (var stat = Stat.FIR; stat <= Stat.LGT; ++stat)
            {
                BuffStat(target, stat, buffMod);
            }
        }

        protected void BuffResistanceStats(ICharacter target, double buffMod)
        {
            for (var stat = Stat.PSN; stat <= Stat.SIL; ++stat)
            {
                BuffStat(target, stat, buffMod);
            }
        }

        #region Total Stat Functions

        #region BaseStats

        protected double HP(ICharacter character)
        {
            return character.TotalStat(BaseStat.HP);
        }

        protected double MP(ICharacter character)
        {
            return character.TotalStat(BaseStat.MP);
        }

        protected double AD(ICharacter character)
        {
            return character.TotalStat(BaseStat.AD);
        }

        protected double MD(ICharacter character)
        {
            return character.TotalStat(BaseStat.MD);
        }

        protected double DEF(ICharacter character)
        {
            return character.TotalStat(BaseStat.DEF);
        }

        protected double MR(ICharacter character)
        {
            return character.TotalStat(BaseStat.MR);
        }

        protected double EVA(ICharacter character)
        {
            return character.TotalStat(BaseStat.EVA);
        }

        protected double SPD(ICharacter character)
        {
            return character.TotalStat(BaseStat.SPD);
        }

        protected double CHA(ICharacter character)
        {
            return character.TotalStat(BaseStat.CHA);
        }

        #endregion

        #region Masteries

        protected double FIR(ICharacter character)
        {
            return character.TotalStat(EleMastery.FIR);
        }

        protected double WAT(ICharacter character)
        {
            return character.TotalStat(EleMastery.WAT);
        }

        protected double ICE(ICharacter character)
        {
            return character.TotalStat(EleMastery.ICE);
        }

        protected double ARC(ICharacter character)
        {
            return character.TotalStat(EleMastery.ARC);
        }

        protected double WND(ICharacter character)
        {
            return character.TotalStat(EleMastery.WND);
        }

        protected double HOL(ICharacter character)
        {
            return character.TotalStat(EleMastery.HOL);
        }

        protected double DRK(ICharacter character)
        {
            return character.TotalStat(EleMastery.DRK);
        }

        protected double GRN(ICharacter character)
        {
            return character.TotalStat(EleMastery.GRN);
        }

        protected double LGT(ICharacter character)
        {
            return character.TotalStat(EleMastery.LGT);
        }

        #endregion

        #region DebuffResistances

        protected double PSN(ICharacter character)
        {
            return character.TotalStat(DebuffResistance.PSN);
        }

        protected double PAR(ICharacter character)
        {
            return character.TotalStat(DebuffResistance.PAR);
        }

        protected double DTH(ICharacter character)
        {
            return character.TotalStat(DebuffResistance.DTH);
        }

        protected double SIL(ICharacter character)
        {
            return character.TotalStat(DebuffResistance.SIL);
        }

        #endregion

        #endregion
    }
}