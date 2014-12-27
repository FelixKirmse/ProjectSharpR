function GetTargetType()
    return Single
end

function GetName()
return "Secret Technique #48"
end

function GetDescription()
return "An attacked that is enhanced by darkness."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .3
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (4.5 * aAD * (aDRK/100) - 1.125 * dDEF) * (100/dDRK)
  d:TakeDamage(damage)
end
