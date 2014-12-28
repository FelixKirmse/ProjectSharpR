function GetTargetType()
    return Enemies
end

function GetName()
  return "Timestop"
end

function GetDescription()
  return "Stop the time for your enemies.\nReduces SPD and is nearly guaranteed to inflict PAR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .6
end

function GetDelay()
  return 0
end

function GetSpellType()
  return Pure
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = .5 * aMD  

  d:BuffStat(SPD, -1)
  d:ApplyDebuff(PAR, 120)

  d:TakeDamage(damage)
end
