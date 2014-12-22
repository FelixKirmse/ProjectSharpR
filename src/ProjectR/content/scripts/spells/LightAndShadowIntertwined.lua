function GetTargetType()
    return Enemies
end

function GetName()
  return "Light and Shadow Intertwined"
end

function GetDescription()
  return "Twilight surrounds your enemies.\nReduces SPD and can inflict PAR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .64
end

function GetDelay()
  return .4
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK, HOL }
end

function SpellEffect()
  local damage = (3.75 * aMD * ((aHOL + aDRK) / 200) - 1.5 * dMR) * (200 / (dHOL + dDRK))
  d:BuffStat(SPD, -.15)
  d:ApplyDebuff(PAR, 35)
  d:TakeDamage(damage)
end
