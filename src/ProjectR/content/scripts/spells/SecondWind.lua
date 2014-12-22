function GetTargetType()
    return Single
end

function GetName()
  return "Second Wind"
end

function GetDescription()
    return "Heal target with the power of the wind."
end

function IsSupportSpell()
    return true
end

function GetMPCost()
    return .18
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local healing = 1.8 * aMD * (aWND/100)
  d:Heal(healing)
end
