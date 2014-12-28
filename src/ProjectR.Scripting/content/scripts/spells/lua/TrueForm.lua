function GetTargetType()
    return Myself
end

function GetName()
return "True Form"
end

function GetDescription()
  return "Reveal your true form, sacrificing defense for pure offense.\nThis spell has no delay."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .75
end

function GetDelay()
  return .99
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  a:BuffStat(SPD, 2)
  a:BuffStat(AD, 2)
  a:BuffStat(DEF, -1)
  a:BuffStat(MR, -1)
end
