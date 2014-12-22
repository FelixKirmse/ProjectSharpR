function GetTargetType()
    return Single
end

function GetName()
return "Blessing of the Wind God"
end

function GetDescription()
    return "Bless the target, enhancing defensive capabilities."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return .12
end

function GetDelay()
  return .65
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  d:BuffStat(DEF, .5)
  d:BuffStat(MR, .5)
end
