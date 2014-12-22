function GetTargetType()
  return Enemies
end

function GetName()
  return "Hellfire Flare"
end

function GetDescription()
  return "Shoot a massive ball of hellfire at your enemies.\nHuge delay."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1.68
end

function GetDelay()
  return 0
end

function GetSpellType()
  return Pure
end

function GetMasteries()
  return { FIR }
end

function SpellEffect()
  local damage = 3.5 * aMD * (aFIR/100)
  d:TakeDamage(damage)
end
