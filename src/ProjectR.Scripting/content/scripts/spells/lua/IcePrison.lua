function GetTargetType()
    return Enemies
end

function GetName()
return "Ice Prison"
end

function GetDescription()
    return "Imprison every enemy within ice.\nCan inflict PAR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .4
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { ICE }
end

function SpellEffect()
  local damage = (3.3 * aAD * (aICE/100) - .825 * dDEF) * (100/dICE)  
  d:ApplyDebuff(PAR, 35)
  d:TakeDamage(damage)
end
