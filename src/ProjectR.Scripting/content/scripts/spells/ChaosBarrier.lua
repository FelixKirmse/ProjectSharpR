function GetTargetType()
  return Single
end

function GetName()
  return "Chaos Barrier"
end

function GetDescription()
  return "Summon a small barrier that decreases damage done\nand increases damage taken.\nReduces AD, MD, DEF & MR."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return .48
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { HOL }
end

function SpellEffect()
  local damage = (3.75 * aMD * (aHOL/100) - 1.25 * dMR) * (100/dHOL)
  d:BuffStat(AD, -.15)
  d:BuffStat(MD, -.15)
  d:BuffStat(DEF, -.15)
  d:BuffStat(MR, -.15)
  d:TakeDamage(damage)
end
