function GetTargetType()
    return Single
end

function GetName()
  return "Scythe of the Doomed"
end

function GetDescription()
    return "Slash at the life source of your target.\nChance to instantly kill target."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .32
end

function GetDelay()
  return .45
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = 2.7225 * aAD - .825 * dDEF
  d:ApplyDebuff(DTH, 40)
  d:TakeDamage(damage)
end
