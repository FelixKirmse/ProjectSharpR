function GetTargetType()
    return Enemies
end

function GetName()
return "Tornado"
end

function GetDescription()
  return "Summon a tornado to blow your enemies away.\nIneffective against targets with high MR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .3
end

function GetDelay()
  return .25
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (4.5 * aMD * (aWND/100) - 2.25 * dMR) * (100/dWND)
  d:TakeDamage(damage)
end
