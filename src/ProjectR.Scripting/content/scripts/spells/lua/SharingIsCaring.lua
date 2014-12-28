function GetTargetType()
    return Single
end

function GetName()
  return "Sharing is caring"
end

function GetDescription()
    return "Imbue your target with the power of the wind.\nLow delay.\nIncreases SPD."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return .28
end

function GetDelay()
  return .75
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  d:BuffStat(SPD, .5)
end
