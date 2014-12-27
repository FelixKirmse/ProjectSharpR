function GetTargetType()
    return Single
end

function GetName()
  return "Empowering Laser"
end

function GetDescription()
    return "Cast a massive arcane laser.\nOnly effective against low MR enemies. Increases your MR."
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
  return { ARC }
end

function SpellEffect()
  local damage = (5 * aMD * (aARC/100) - 2.5 * dMR) * (100/dARC)  
  a:BuffStat(MR, .25)
  d:TakeDamage(damage)
end
