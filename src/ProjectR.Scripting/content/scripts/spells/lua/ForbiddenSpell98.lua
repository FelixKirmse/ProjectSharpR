function GetTargetType()
    return Single
end

function GetName()
return "Forbidden Spell #98"
end

function GetDescription()
  return "Focuses all your arcane power into\nannihilating your target.\nIgnores most of target's MR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 2
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Pure
end

function GetMasteries()
  return { ARC }
end

function SpellEffect()
  local damage = 10 * aMD * (aARC/100) - .3 * dMR
  d:TakeDamage(damage)
end
