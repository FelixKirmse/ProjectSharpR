using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting
{
    // ReSharper disable InconsistentNaming
    public abstract class SpellScriptBase : SpellBase
    {
        private static IScriptHelper ScriptHelper { get { return RHelper.ScriptHelper; } }

        protected void AddSpell(ICharacter character, string spellName)
        {
            ScriptHelper.AddSpell(character, spellName);
        }

        protected IEnumerable<ICharacter> GetCasterParty()
        {
            return ScriptHelper.GetCasterParty();
        }

        protected IEnumerable<ICharacter> GetCasterReserveParty()
        {
            return ScriptHelper.GetCasterReserveParty();
        }

        protected ICharacter SummonMinionCopyAmongEnemy(ICharacter target, string name)
        {
            return ScriptHelper.SummonMinionCopyAmongEnemy(target, name);
        }

        protected ICharacter SummonMinionCopy(ICharacter target, string name)
        {
            return ScriptHelper.SummonMinionCopy(target, name);
        }

        protected double GetDeathCountOfAttackerParty()
        {
            return ScriptHelper.GetDeathCountOfAttackerParty();
        }

        protected void RemoveStatDebuffs()
        {
            RemoveStatDebuffs(Target);
        }

        protected void RemoveStatBuffs()
        {
            RemoveStatBuffs(Target);
        }

        protected void RemoveStatBuffs(ICharacter target)
        {
            target.Stats.RemoveBuffs();
        }

        protected void RemoveStatDebuffs(ICharacter target)
        {
            target.Stats.RemoveDebuffs();
        }

        protected void RemoveDebuffs()
        {
            RemoveDebuffs(Target);
        }

        protected void RemoveDebuffs(ICharacter target)
        {
            ScriptHelper.RemoveDebuffs(target);
        }

        protected void DealDamage(ICharacter target, double damage)
        {
            ScriptHelper.DealDamage(target, damage);
        }

        protected void DealDamage(double damage)
        {
            DealDamage(Target, damage);
        }

        protected void DealDamage(IList<ICharacter> targets, double damage)
        {
            foreach (var target in targets)
            {
                DealDamage(target, damage);
            }
        }

        protected void Heal(ICharacter target, double healing)
        {
            ScriptHelper.Heal(target, healing);
        }

        protected void Heal(double healing)
        {
            Heal(Target, healing);
        }

        protected void TryToApplyDebuff(ICharacter target, DebuffResistance type, int applyChance)
        {
            ScriptHelper.TryToApplyDebuff(target, type, applyChance);
        }

        protected void TryToApplyDebuff(DebuffResistance type, int applyChance)
        {
            TryToApplyDebuff(Target, type, applyChance);
        }

        protected void BuffStat(ICharacter target, Stat stat, double buffMod)
        {
            target.BuffStat(stat, buffMod);
        }

        protected void BuffStat(Stat stat, double buffMod)
        {
            BuffStat(Target, stat, buffMod);
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

        protected bool IsEnemy(ICharacter target)
        {
            return ScriptHelper.IsEnemy(target);
        }

        protected double GetVar(ICharacter target, string varName)
        {
            return ScriptHelper.GetVar(target, varName);
        }

        protected void SetVar(ICharacter target, string varName, double value)
        {
            ScriptHelper.SetVar(target, varName, value);
        }

        protected void ApplyAffliction(ICharacter target, string affliction)
        {
            ScriptHelper.ApplyAffliction(target, affliction);
        }

        #region Total Stat Functions
        
        #region BaseStats

        protected double cHP { get { return HP(Caster); } }
        protected double cMP { get { return MP(Caster); } }
        protected double cAD { get { return AD(Caster); } }
        protected double cMD { get { return MD(Caster); } }
        protected double cDEF { get { return DEF(Caster); } }
        protected double cMR { get { return MR(Caster); } }
        protected double cEVA { get { return EVA(Caster); } }
        protected double cSPD { get { return SPD(Caster); } }
        protected double cCHA { get { return CHA(Caster); } }

        protected double tHP { get { return HP(Target); } }
        protected double tMP { get { return MP(Target); } }
        protected double tAD { get { return AD(Target); } }
        protected double tMD { get { return MD(Target); } }
        protected double tDEF { get { return DEF(Target); } }
        protected double tMR { get { return MR(Target); } }
        protected double tEVA { get { return EVA(Target); } }
        protected double tSPD { get { return SPD(Target); } }
        protected double tCHA { get { return CHA(Target); } }

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

        protected double cFIR { get { return FIR(Caster); } }
        protected double cWAT { get { return WAT(Caster); } }
        protected double cICE { get { return ICE(Caster); } }
        protected double cARC { get { return ARC(Caster); } }
        protected double cWND { get { return WND(Caster); } }
        protected double cHOL { get { return HOL(Caster); } }
        protected double cDRK { get { return DRK(Caster); } }
        protected double cGRN { get { return GRN(Caster); } }
        protected double cLGT { get { return LGT(Caster); } }

        protected double tFIR { get { return FIR(Target); } }
        protected double tWAT { get { return WAT(Target); } }
        protected double tICE { get { return ICE(Target); } }
        protected double tARC { get { return ARC(Target); } }
        protected double tWND { get { return WND(Target); } }
        protected double tHOL { get { return HOL(Target); } }
        protected double tDRK { get { return DRK(Target); } }
        protected double tGRN { get { return GRN(Target); } }
        protected double tLGT { get { return LGT(Target); } }

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

        protected double cPSN { get { return PSN(Caster); } }
        protected double cPAR { get { return PAR(Caster); } }
        protected double cDTH { get { return DTH(Caster); } }
        protected double cSIL { get { return SIL(Caster); } }

        protected double tPSN { get { return PSN(Target); } }
        protected double tPAR { get { return PAR(Target); } }
        protected double tDTH { get { return DTH(Target); } }
        protected double tSIL { get { return SIL(Target); } }

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

        #region Legacy Total Stat Functions
        // These identifiers where used in the lua scripts in the C++ version. For easier porting I added these. 

        #region BaseStats

        protected double aHP { get { return HP(Caster); } }
        protected double aMP { get { return MP(Caster); } }
        protected double aAD { get { return AD(Caster); } }
        protected double aMD { get { return MD(Caster); } }
        protected double aDEF { get { return DEF(Caster); } }
        protected double aMR { get { return MR(Caster); } }
        protected double aEVA { get { return EVA(Caster); } }
        protected double aSPD { get { return SPD(Caster); } }
        protected double aCHA { get { return CHA(Caster); } }

        protected double dHP { get { return HP(Target); } }
        protected double dMP { get { return MP(Target); } }
        protected double dAD { get { return AD(Target); } }
        protected double dMD { get { return MD(Target); } }
        protected double dDEF { get { return DEF(Target); } }
        protected double dMR { get { return MR(Target); } }
        protected double dEVA { get { return EVA(Target); } }
        protected double dSPD { get { return SPD(Target); } }
        protected double dCHA { get { return CHA(Target); } }
        #endregion

        #region Masteries

        protected double aFIR { get { return FIR(Caster); } }
        protected double aWAT { get { return WAT(Caster); } }
        protected double aICE { get { return ICE(Caster); } }
        protected double aARC { get { return ARC(Caster); } }
        protected double aWND { get { return WND(Caster); } }
        protected double aHOL { get { return HOL(Caster); } }
        protected double aDRK { get { return DRK(Caster); } }
        protected double aGRN { get { return GRN(Caster); } }
        protected double aLGT { get { return LGT(Caster); } }

        protected double dFIR { get { return FIR(Target); } }
        protected double dWAT { get { return WAT(Target); } }
        protected double dICE { get { return ICE(Target); } }
        protected double dARC { get { return ARC(Target); } }
        protected double dWND { get { return WND(Target); } }
        protected double dHOL { get { return HOL(Target); } }
        protected double dDRK { get { return DRK(Target); } }
        protected double dGRN { get { return GRN(Target); } }
        protected double dLGT { get { return LGT(Target); } }

        #endregion

        #region DebuffResistances

        protected double aPSN { get { return PSN(Caster); } }
        protected double aPAR { get { return PAR(Caster); } }
        protected double aDTH { get { return DTH(Caster); } }
        protected double aSIL { get { return SIL(Caster); } }

        protected double dPSN { get { return PSN(Target); } }
        protected double dPAR { get { return PAR(Target); } }
        protected double dDTH { get { return DTH(Target); } }
        protected double dSIL { get { return SIL(Target); } }

        #endregion

        #endregion
    }
    // ReSharper restore InconsistentNaming
}