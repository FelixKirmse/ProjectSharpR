function GetTargetType()
    return Allies
end

function GetName()
  return "Inspiring Speech"
end

function GetDescription()
  return "Hold an incredibly inspiring speech.\nIncreases AD, MD, DEF & MR significantly.\nUses up all your MP."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1.88
end

function GetDelay()
  return 0
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  a:UseMP(200)
  d:BuffStat(AD, 2)
  d:BuffStat(MD, 2)
  d:BuffStat(DEF, 2)
  d:BuffStat(MR, 2)
end
