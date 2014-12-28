function GetTargetType()
    return Single
end

function GetName()
  return "Wind Strike"
end

function GetDescription()
    return "Strike with the power of the wind."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .32
end

function GetDelay()
  return .65
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (3.3 * aAD * (aWND/100) - dDEF) * (100/dWND)
  d:TakeDamage(damage)
end
