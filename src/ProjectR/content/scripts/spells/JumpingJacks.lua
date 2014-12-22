function GetTargetType()
    return Single
end

function GetName()
  return "Jumping Jacks"
end

function GetDescription()
  return "Throw jumping jacks at an enemy."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .5
end

function GetDelay()
  return .2
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (7.95 * aAD * (aDRK/100) - 1.325 * dDEF) * (100/dDRK)
  d:TakeDamage(damage)
end
