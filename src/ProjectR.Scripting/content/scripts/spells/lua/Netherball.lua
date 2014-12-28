function GetTargetType()
    return Single
end

function GetName()
    return "Netherball"
end

function GetDescription()
    return "Shoot a weak Netherball at your enemies. Recovers some MP."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Pure
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    d:TakeDamage(aAD + aMD)
    a:UseMP(-(aMP * .2))
end
