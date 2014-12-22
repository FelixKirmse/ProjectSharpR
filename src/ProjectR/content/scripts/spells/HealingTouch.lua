function GetTargetType()
    return Single
end

function GetName()
    return "Healing Touch"
end

function GetDescription()
    return "Slighty heals your target and restores some of your MP."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    d:Heal(aAD + aMD)
    a:UseMP(-(aMP * .2))
end
