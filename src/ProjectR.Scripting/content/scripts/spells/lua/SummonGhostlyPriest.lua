function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Ghostly Priest"
end

function GetDescription()
    return "Summons a Ghostly Priest that casts support spells on your party."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1
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
    local minion = SummonMinionCopy(a, "Ghostly Priest")
    minion:ClearSpells()
    minion:AddSpell("Healing Touch")
    minion:AddSpell("Healing Touch")
    minion:AddSpell("Cleanse")
    minion:AddSpell("Blessed Ground")
    minion:AddSpell("Sharing is caring")
end
