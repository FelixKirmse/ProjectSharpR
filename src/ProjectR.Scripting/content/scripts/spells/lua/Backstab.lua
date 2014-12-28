function GetTargetType()
    return Single
end

function GetName()
    return "Backstab!"
end

function GetDescription()
    return "Deal high composite damage to ally target. Deals no damage if used against enemies."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Composite
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    local damage = 10 * aAD + 10 * aMD - dDEF - dMR

    if d:IsEnemy() then
      damage = 0
    end

    d:TakeDamage(damage)
end
