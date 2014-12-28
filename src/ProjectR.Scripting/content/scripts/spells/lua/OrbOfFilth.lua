function GetTargetType()
    return Enemies
end

function GetName()
return "Orb of Filth"
end

function GetDescription()
return "Summon an orb of filth among the enemy ranks that explodes.\nChance to inflict poison."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .3
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (2 * aMD * (aDRK/100) - dMR) * (100/dDRK)  
  d:ApplyDebuff(PSN, 60)
  d:TakeDamage(damage)
end
