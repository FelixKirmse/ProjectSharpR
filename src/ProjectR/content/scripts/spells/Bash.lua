function GetTargetType()
    return Single
end

function GetName()
    return "Bash"
end

function GetDescription()
    return "Bash your target, dazing it."
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
  return Physical
end

function GetMasteries()
  return {  }
end

function SpellEffect()
    local damage = .5 * aAD - dDEF
    d:ApplyAffliction("Mini Stun")
    d:SetVar("ministun_Strength", d:GetVar("ministun_Strength") * .2)
    d:TakeDamage(damage)
end
