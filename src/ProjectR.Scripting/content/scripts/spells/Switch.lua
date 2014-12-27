function GetTargetType()
    return Single
end

function GetName()
    return "Switch"
end

function GetDescription()
    return "Two Characters have been switched"
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
end
