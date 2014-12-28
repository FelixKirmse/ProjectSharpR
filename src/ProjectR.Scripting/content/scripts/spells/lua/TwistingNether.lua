function GetTargetType()
    return Enemies
end

function GetName()
return "Twisting Nether"
end

function GetDescription()
return "Twist space around your enemies, dealing high damage.\nLong delay."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1.38
end

function GetDelay()
  return 0
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { HOL }
end

function SpellEffect()
  local damage = (6 * aMD * (aHOL/100) - 1.5 * dMR) * (100/dHOL)
  d:TakeDamage(damage)
end
