function GetTargetType()
    return Single
end

function GetName()
return "Quick Surprise"
end

function GetDescription()
  return "A quick strike with low recovery.\nThe enemy is unable to fully prepare for the attack."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .18
end

function GetDelay()
  return .85
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = 2.5 * aAD - .625 * dDEF
  d:TakeDamage(damage)
end
