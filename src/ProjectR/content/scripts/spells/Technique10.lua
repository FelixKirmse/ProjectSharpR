function GetTargetType()
    return Enemies
end

function GetName()
  return "Technique #10"
end

function GetDescription()
  return "Attack all enemies with magic-enchanted attacks."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1.32
end

function GetDelay()
  return .2
end

function GetSpellType()
  return Composite
end

function GetMasteries()
  return {  }
end

function SpellEffect()
  local damage = (3 * aAD + 3 * aMD)  - (dDEF + dMR)
 d:TakeDamage(damage)
end
