function GetTargetType()
    return Enemies
end

function GetName()
  return "Amazing Bitchslap X11"
end

function GetDescription()
    return "Extend your arm to bitchslap all enemies, WTF?!"
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .5
end

function GetDelay()
  return .36
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (5 * aAD * (aDRK/100) - 1.25 * dDEF) * (100/dDRK)
  d:TakeDamage(damage)
end
