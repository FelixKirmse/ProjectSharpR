function GetTargetType()
    return Enemies
end

function GetName()
return "Icicle Barrage"
end

function GetDescription()
    return "Summon icicles to impale your enemies.\nPierces MR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .3
end

function GetDelay()
  return .25
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { ICE }
end

function SpellEffect()
  local damage = (2.5 * aMD * (aICE/100) - .5 * dMR) * (100/dICE)
  d:TakeDamage(damage)
end
