function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Trickster"
end

function GetDescription()
    return "Summons a Trickster that debuffs enemies."
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
    local minion = SummonMinionCopy(a, "Trickster")
    minion:ClearSpells()
    minion:AddSpell("Sniff my finger!")
    minion:AddSpell("Sniff my finger!")
    minion:AddSpell("Crippling Aura")
    minion:AddSpell("Poison Flight")
    minion:AddSpell("Stun Bomb")
end
