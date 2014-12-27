function GetTargetType()
    return Single
end

function GetName()
    return "Ram"
end

function GetDescription()
    return "Ram your target causing damage proportional to your DEF."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    local damage = aDEF - dDEF
    d:TakeDamage(damage)
end
