function GetTargetType()
    return Myself
end

function GetName()
return "Optical Camouflage X69"
end

function GetDescription()
    return "Vanish before your foes.\nIncreases defensive stats, lolumad?"
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .64
end

function GetDelay()
  return .36
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  a:BuffStat(EVA, .66)
  a:BuffStat(DEF, .5)
  a:BuffStat(MR, .5)
  a:BuffStat(SPD, .5)
end
