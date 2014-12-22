function GetTargetType()
  return Single
end

function GetName()
  return "Shadow Shot"
end

function GetDescription()
  return "Focus your energy into a shadowball."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .32
end

function GetDelay()
  return .66
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (3.0625 * aMD * (aDRK/100) - .875 * dMR) * (100/dDRK)
  d:TakeDamage(damage)
end
