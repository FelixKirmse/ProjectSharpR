function GetTargetType()
    return Enemies
end

function GetName()
return "Acidic Sea"
end

function GetDescription()
return "A sea of acid surrounds the enemy.\nLowers enemies AD."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .6
end

function GetDelay()
  return .3
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { WAT }
end

function SpellEffect()
  local damage = (3.0625 * aMD * (aWAT/100) - .875 * dMR) * (100/dWAT)
  d:BuffStat(AD, -0.18)
  d:TakeDamage(damage);
end
