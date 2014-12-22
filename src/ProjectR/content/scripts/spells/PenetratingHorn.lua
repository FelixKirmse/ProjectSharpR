function GetTargetType()
    return Single
end

function GetName()
  return "Penetrating Horn"
end

function GetDescription()
  return "Ram your horn into your target.\nUseful against high DEF enemies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .36
end

function GetDelay()
  return .45
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (2.25 * aAD * (aDRK/100) - .5 * dDEF) * (100/dDRK)
  d:TakeDamage(damage)
end
