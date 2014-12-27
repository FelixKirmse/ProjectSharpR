function GetTargetType()
    return Single
end

function GetName()
  return "Shadow Ray"
end

function GetDescription()
    return "Focus a ray of shadow energy onto target."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .32
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (6.625 * aMD * (aDRK/100) - 1.325 * dMR) * (100/dDRK)
  d:TakeDamage(damage)
end
