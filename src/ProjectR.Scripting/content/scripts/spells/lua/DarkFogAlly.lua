function GetTargetType()
    return Allies
end

function GetName()
  return "Dark Fog (Ally)"
end

function GetDescription()
    return "Summon a fog that removes all debuffs and heals a little."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .36
end

function GetDelay()
  return .3
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  local healing = .25 * aMD * (aDRK/100)
  d:RemoveDebuffs()

  d:Heal(healing)
end
