function GetTargetType()
    return Single
end

function GetName()
  return "Fiery Fury Fist"
end

function GetDescription()
    return "Strike with your flame-imbued fist.\nThe heat causes you to ignore some of the enemies DEF."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .58
end

function GetDelay()
  return 0
end

function GetSpellType()
  return Physical
end

function GetMasteries()
  return { FIR }
end

function SpellEffect()
  local damage = (5 * aAD * (aFIR/100) - .8 * dDEF) * (100/dFIR)
  d:TakeDamage(damage)
end
