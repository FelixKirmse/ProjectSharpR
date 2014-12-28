function GetTargetType()
    return Enemies
end

function GetName()
  return "Hurricane"
end

function GetDescription()
    return "Summon a hurricane to blast away your enemies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .6
end

function GetDelay()
  return .28
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (4.375 * aMD * (aWND/100) - .875 * dMR) * (100/dWND)
  d:TakeDamage(damage)
end
