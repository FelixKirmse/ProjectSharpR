function GetTargetType()
    return Single
end

function GetName()
  return "Fuzzy Overhaul"
end

function GetDescription()
  return "Cleanse target from all buffs and debuffs."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  d:RemoveDebuffs()
  ds:RemoveBuffs()
end
