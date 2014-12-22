function GetTargetType()
    return Single
end

function GetName()
  return "One At A Time"
end

function GetDescription()
  return "Focus your attacks on one enemy.\nHigh Delay."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .8
end

function GetDelay()
  return 0
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (10 * aAD * (aWND/100) - .8 * dDEF) * (100/dWND)
  d:TakeDamage(damage)
end
