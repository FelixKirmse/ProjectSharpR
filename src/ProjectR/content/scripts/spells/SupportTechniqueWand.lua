function GetTargetType()
  return Allies
end

function GetName()
  return "Support Technique: Wand"
end

function GetDescription()
  return "Increases MD of all allies."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .8
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
  d:BuffStat(MD, .48)
end
