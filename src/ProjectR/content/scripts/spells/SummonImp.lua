function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Imp"
end

function GetDescription()
    return "Summons an Imp that casts damage spells."
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
    local minion = SummonMinionCopy(a, "Imp")
    minion:ClearSpells()
    minion:AddSpell("Netherball")
    minion:AddSpell("Netherball")
    minion:AddSpell("Fire Wheel")
    minion:AddSpell("Piercing Flames")
    minion:AddSpell("Haunt")
end
