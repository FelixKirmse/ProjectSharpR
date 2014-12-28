function GetTargetType()
    return Enemies
end

function GetName()
  return "Magic Sap"
end

function GetDescription()
    return "Sap the magic energy of your enemies.\nSlighty reduces enemies MD."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = 4.125 * aMD - 1.375 * dMR  
  d:BuffStat(MD, -.18)
  d:TakeDamage(damage)
end
