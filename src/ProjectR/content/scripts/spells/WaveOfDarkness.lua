function GetTargetType()
    return Enemies
end

function GetName()
  return "Wave of Darkness"
end

function GetDescription()
    return "Similar to Tsunami, but with a different element.\nReduces enemies DEF."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .55
end

function GetDelay()
  return .28
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (4.5 * aMD * (aDRK/100) - 1.125 * dMR) * (100/dDRK)  
  d:BuffStat(DEF, -.15)
  d:TakeDamage(damage)
end
