function GetTargetType()
    return Single
end

function GetName()
    return "Inspire"
end

function GetDescription()
    return "Inspire target, slightly rasing their offense. Also restores some of casters MP."
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
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    d:BuffStat(AD, .2)
    d:BuffStat(MD, .2)
    a:UseMP(-(aMP * .2))
end
