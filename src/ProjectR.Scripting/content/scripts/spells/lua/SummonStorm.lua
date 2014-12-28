function GetTargetType()
    return Enemies
end

function GetName()
  return "Summon Storm"
end

function GetDescription()
    return "Summons a relatively weak storm to attack the enemies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (2.5 * aAD * (aWND/100) - 1.25 * dDEF) * (100/dWND)
  d:TakeDamage(damage)
end
