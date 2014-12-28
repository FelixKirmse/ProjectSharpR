function GetTargetType()
    return Enemies
end

function GetName()
  return "Storm Dash"
end

function GetDescription()
    return "Quickly strike all enemies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .5
end

function GetDelay()
  return .6
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (2.875 * aAD * (aWND/100) - 1.25 * dDEF) * (100/dWND)
  d:TakeDamage(damage)
end
