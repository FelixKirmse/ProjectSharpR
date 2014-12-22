function GetTargetType()
    return Single
end

function GetName()
  return "Shadow Trap"
end

function GetDescription()
    return "Entrap your target and try to inject a deadly poison into it."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .32
end

function GetDelay()
  return .65
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = 1.5 * aAD - .5 * dDEF  
  d:ApplyDebuff(PSN, 60)
  d:ApplyDebuff(PAR, 30)
  d:TakeDamage(damage)
end
