function GetTargetType()
    return Enemies
end

function GetName()
  return "Hand of Death"
end

function GetDescription()
  return "Attempt to kill all enemies.\nHigh damage modifier."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1.88
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
  d:ApplyDebuff(DTH, 100)
  local damage = (9 * aMD * (aDRK/100) - 1.5 * dMR) * (100/dDRK)
  d:TakeDamage(damage)
end
