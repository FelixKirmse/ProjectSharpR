function GetTargetType()
    return Enemies
end

function GetName()
  return "Piercing Flames"
end

function GetDescription()
return "Piercing hot flames attack all enemies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .64
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Pure
end

function GetMasteries()
  return { FIR }
end

function SpellEffect()
  local damage = 2.5 * aMD * (aFIR/100)
  d:TakeDamage(damage)
end
