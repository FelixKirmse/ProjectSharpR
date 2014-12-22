function GetTargetType()
    return Decaying
end

function GetName()
  return "Hidden Seal #37"
end

function GetDescription()
    return "Something unknown surges through your enemies.\nDeals damage based on proximity to target."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .66
end

function GetDelay()
  return .45
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = (4 * aMD - dMR) / modifier
  d:TakeDamage(damage)
end
