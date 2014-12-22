function GetTargetType()
    return Enemies
end

function GetName()
  return "Thousand Needles"
end

function GetDescription()
    return "Wears down the enemies defense."
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
  return {  }
end

function SpellEffect()
  local damage = 4 * aMD - dDEF  
  d:BuffStat(DEF, -.25)
  d:TakeDamage(damage)
end
