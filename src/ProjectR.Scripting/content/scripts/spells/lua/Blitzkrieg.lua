function GetTargetType()
    return Allies
end

function GetName()
return "Blitzkrieg"
end

function GetDescription()
    return "Use the moment of surprise and increase SPD of all allies by 40%%."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1.22
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
  d:BuffStat(SPD, .4)  
end
