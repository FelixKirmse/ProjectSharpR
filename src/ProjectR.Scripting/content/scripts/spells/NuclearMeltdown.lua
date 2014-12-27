function GetTargetType()
  return Myself
end

function GetName()
  return "Nuclear Meltdown"
end

function GetDescription()
  return "Overheat yourself, sacrificing DEF & MR for MD.\nAlso deals FIR damage to all enemies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .8
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { FIR }
end

function SpellEffect()
  a:BuffStat(MD, .35)
  a:BuffStat(MR, -.2)
  a:BuffStat(DEF, -.2)
  ForEachDefenderParty("MeltdownDamageCalc")
end

function MeltdownDamageCalc(character)
  local defStats = GetStats(character)
  local defMR = defStats:GetTotalStat(MR)
  local defFIR = defStats:GetTotalStat(FIR)

  local damage = (2.25 * aMD * (aFIR/100) - .75 * defMR) * (100/defFIR)
  character:TakeDamage(damage)
end
