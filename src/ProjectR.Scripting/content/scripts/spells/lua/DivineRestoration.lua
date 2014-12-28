function GetTargetType()
    return Single
end

function GetName()
  return "Divine Restoration"
end

function GetDescription()
    return "Heal and cleanse your target of all debuffs.\nHeal affected by HOL of both caster and target."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .25
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { HOL }
end

function SpellEffect()
  local healing = aMD * (aHOL/dHOL)  
  d:RemoveDebuffs()
  d:Heal(healing)
end
