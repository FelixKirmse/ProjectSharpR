function GetTargetType()
    return Myself
end

function GetName()
    return "Summon: Divine Duo"
end

function GetDescription()
    return "Summons Heel Yu and Boff Yu to aid your party."
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
    local minion2 = SummonMinionCopy(a, "Boff Yu")
    minion2:ClearSpells()
    minion2:AddSpell("Inspire")
    minion2:AddSpell("Inspire")
    minion2:AddSpell("Blessing of the Gods")
    minion2:AddSpell("Blessing of the Wind God")
    minion2:AddSpell("Miracle Poke")
    minion2:AddSpell("Sharing is caring")
    minion2:AddSpell("Barrier of Faith")

    local minion = SummonMinionCopy(a, "Heel Yu")
    minion:ClearSpells()
    minion:AddSpell("Healing Touch")
    minion:AddSpell("Healing Touch")
    minion:AddSpell("Healing Rain")
    minion:AddSpell("Blessed Ground")
    minion:AddSpell("Dark Fog (Ally)")
    minion:AddSpell("Dark Mend")
    minion:AddSpell("Divine Restoration")
    minion:AddSpell("Second Wind")
end
