function GetTargetType()
    return Single
end

function GetName()
    return "Slash"
end

function GetDescription()
    return "A sword slash that ignores some of the targets DEF."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .35
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    local damage = 1.5 * aAD - .75 * dDEF
    d:TakeDamage(damage)
end
