function GetTargetType()
  return Enemies
end

function GetName()
  return "Poison Flight"
end

function GetDescription()
  return "Fly among the enemy ranks leaving a poison trail behind you.\nChance to inflict PAR and PSN."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .8
end

function GetDelay()
  return .25
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local damage = (4 * aAD * (aDRK/100) - dDEF) * (100/dDRK)  
  d:ApplyDebuff(PAR, 70)
  d:ApplyDebuff(PSN, 70)
  d:TakeDamage(damage)
end
