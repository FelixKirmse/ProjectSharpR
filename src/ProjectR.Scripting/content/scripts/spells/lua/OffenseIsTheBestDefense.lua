function GetTargetType()
  return Enemies
end

function GetName()
  return "Offense Is The Best Defense"
end

function GetDescription()
  return "Fast as the wind you attack all enemies and try to PAR them."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .8
end

function GetDelay()
  return .35
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = 6 * aAD - 1.5 * dDEF  
  d:ApplyDebuff(PAR, 20)
  d:TakeDamage(damage)
end
