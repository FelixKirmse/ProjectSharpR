function GetTargetType()
  return Allies
end

function GetName()
 return "Barrier of Faith"
end

function GetDescription()
  return "Holy power flows through everyone in your party.\nIncreases DEF and MR."
end

function IsSupportSpell()
  return true
end

function GetMPCost()
  return .88
end

function GetDelay()
  return .3
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
