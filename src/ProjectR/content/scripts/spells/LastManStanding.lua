function GetTargetType()
    return Single
end

function GetName()
  return "Last Man Standing"
end

function GetDescription()
  return "Unleash a spell that deals more damage for each of your dead party members at the front."
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
  local deadCount = GetDeadMemberCountAttackerParty()
  local damage = ((6 * deadCount) * aMD - 1.5 * dMR) * deadCount
  d:TakeDamage(damage)
end
