function GetTargetType()
    return Single
end

function GetName()
    return "Magic Shot"
end

function GetDescription()
    return "Attack your target with a magic projectile."
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
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    local damage = aMD - .8 * dMR
    d:TakeDamage(damage)
end
