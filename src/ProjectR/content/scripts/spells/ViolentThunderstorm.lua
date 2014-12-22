function GetTargetType()
    return Enemies
end

function GetName()
  return "Violent Thunderstorm"
end

function GetDescription()
    return "Summon a violent thunderstorm to annihilate your foes.\nMelts the armor of each target hit."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .38
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { WND }
end

function SpellEffect()
  local damage = (3.8 * aMD * (aWND/100) - .95 * dMR) * (100/dWND)
  d:TakeDamage(damage)
end
