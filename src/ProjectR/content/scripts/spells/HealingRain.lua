function GetTargetType()
    return Allies
end

function GetName()
return "Healing Rain"
end

function GetDescription()
  return "Summon a healing rain that provides good healing to your party."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return .44
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
  local healing = 2.5 * aAD + 2.5 * aMD
  d:Heal(healing)
end
