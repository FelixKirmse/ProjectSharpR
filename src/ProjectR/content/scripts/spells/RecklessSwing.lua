function GetTargetType()
    return Single
end

function GetName()
return "Reckless Swing"
end

function GetDescription()
return "Strike recklessly at your foe.\nAlso damages self slightly."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .66
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = 6.5 * aAD - 1.125 * dDEF
  local selfDamage = .16 * aAD - .2 * aDEF
  a:TakeDamage(selfDamage)
  d:TakeDamage(damage)
end
