function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Chaos Troublemakers"
end

function GetDescription()
    return "Summons Statt and Daun to ruin your enemies day."
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
    local minion2 = SummonMinionCopy(a, "Daun")
    minion2:ClearSpells()
    minion2:AddSpell("Sniff my finger!")
    minion2:AddSpell("Sniff my finger!")
    minion2:AddSpell("Freeze Them To Death!")
    minion2:AddSpell("Orb of Filth")
    minion2:AddSpell("Poison Flight")
    minion2:AddSpell("Shadow Trap")
    minion2:AddSpell("Timestop")

    local minion = SummonMinionCopy(a, "Statt")
    minion:ClearSpells()
    minion:AddSpell("Sniff my finger!")
    minion:AddSpell("Sniff my finger!")
    minion:AddSpell("Cataclysmic Barrier")
    minion:AddSpell("Chaos Barrier")
    minion:AddSpell("Fuck Them Up!")
    minion:AddSpell("Deadly Venom")
    minion:AddSpell("Deadly Swarm")
end
