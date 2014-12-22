function GetTargetType()
    return Enemies
end

function GetName()
  return "Deadly Swarm"
end

function GetDescription()
    return "A swarm of poisonous insects attacks all enemies.\nHigh chance to apply PSN."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .5
end

function GetDelay()
  return .35
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (2.5 * aAD * (aDRK/100) - dDEF) * (100/dDRK)  

  d:ApplyDebuff(PSN, 90)
  d:TakeDamage(damage)
end
