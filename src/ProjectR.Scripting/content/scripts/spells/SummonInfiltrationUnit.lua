function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Infiltration Unit"
end

function GetDescription()
    return "Summons Assa and Sin to wreak havoc among the enemies ranks."
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
    local minion = SummonMinionCopyAmongEnemy(a, "Sin")
    minion:ClearSpells()
    minion:AddSpell("Backstab!")

    local minion2 = SummonMinionCopyAmongEnemy(a, "Assa")
    minion2:ClearSpells()
    minion2:AddSpell("Backstab!")
end
