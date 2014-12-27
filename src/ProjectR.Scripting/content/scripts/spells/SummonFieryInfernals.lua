function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Steam Duo"
end

function GetDescription()
    return "Summons I.C. and Fiahr to overwhelm your enemies."
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
    local minion2 = SummonMinionCopy(a, "Fiahr")
    minion2:ClearSpells()
    minion2:AddSpell("Netherball")
    minion2:AddSpell("Netherball")
    minion2:AddSpell("Extinction")
    minion2:AddSpell("Hellfire Flare")
    minion2:AddSpell("Hell's Inferno")
    minion2:AddSpell("Nuclear Meltdown")
    minion2:AddSpell("Ragnarok")

    local minion = SummonMinionCopy(a, "I.C.")
    minion:ClearSpells()
    minion:AddSpell("Netherball")
    minion:AddSpell("Netherball")
    minion:AddSpell("Frost Blast")
    minion:AddSpell("Frozen Blood")
    minion:AddSpell("Ice Prison")
    minion:AddSpell("Icicle Barrage")
    minion:AddSpell("Breath of the Baby Ice Dragon")
end
