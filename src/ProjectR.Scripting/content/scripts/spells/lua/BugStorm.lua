function GetTargetType()
    return Enemies
end

function GetName()
  return "Bug Storm"
end

function GetDescription()
    return "Millions of bugs storm the enemy."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .66
end

function GetDelay()
  return .30
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
