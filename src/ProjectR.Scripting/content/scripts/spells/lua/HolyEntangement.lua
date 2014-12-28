function GetTargetType()
    return Enemies
end

function GetName()
  return "Holy Entanglement"
end

function GetDescription()
    return "A divine being prevents your enemies from evading.\nReduces enemies EVA."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .46
end

function GetDelay()
  return .35
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { HOL }
end

function SpellEffect()
  local damage = (3.24 * aMD * (aHOL/100) - .9 * dMR) * (100/dHOL)
  d:BuffStat(EVA, -.5)
  d:TakeDamage(damage)
end
