function GetTargetType()
    return Enemies
end

function GetName()
return "Fear of the Dark"
end

function GetDescription()
  return "Darkness surrounds your enemies, driving them insane."
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
  return { DRK }
end

function SpellEffect()
  local damage = (3.24 * aMD * (aDRK/100) - .9 * dMR) * (100/dDRK)
  d:TakeDamage(damage)
end
