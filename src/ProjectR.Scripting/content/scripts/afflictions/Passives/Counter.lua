function GetName()
  return "Counter"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { AttackDodged, AttackBlocked }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == AttackDodged or hookPoint == AttackBlocked then
    local attacker = GetCurrentAttacker()
    attacker:TakeTrueDamage(param1 * 0.2)
  end
end
