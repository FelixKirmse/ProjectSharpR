function GetTargetType()
    return Single
end

function GetName()
    return "Mirror Image"
end

function GetDescription()
    return "Creates two clones of the target to fight by your side. Clones use the same spells as the target."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 2
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
    SummonMinionCopy(d, "Mirror Image")
    SummonMinionCopy(d, "Mirror Image")
end
