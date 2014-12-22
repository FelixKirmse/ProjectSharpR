function GetTargetType()
    return Single
end

function GetName()
    return "Magic Charge"
end

function GetDescription()
    return "Surround yourself in a magic shield and charge at your target. Deals damage according to yoour MR."
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
    local damage = aMR - dMR
    d:TakeDamage(damage)
end

