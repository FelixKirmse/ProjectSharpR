function GetTargetType()
    return Single
end

function GetName()
    return "Sniff my finger!"
end

function GetDescription()
    return "You know exactly what this does. Reduces target DEF + MR and restores some MP."
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
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    d:BuffStat(DEF, -.2)
    d:BuffStat(MR, -.2)
    a:UseMP(-(aMP * .2))
end
