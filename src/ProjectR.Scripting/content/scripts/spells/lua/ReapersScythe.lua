function GetTargetType()
    return Single
end

function GetName()
    return "Reaper's Scythe"
end

function GetDescription()
    return "A deadly slash with your scythe.\nChance to instantly kill target.\nHeals for 100%% of damage done.\nCan't be evaded."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Pure
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
    d:ApplyDebuff(DTH, 30)
    local damage = aAD * (aDRK/dDRK)    
    a:Heal(damage)
    d:TakeDamage(damage)
end
