function GetName()
  return "Glass Bones"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { Attacking, TakingDamage }
end

function OnAttachment(char)
  char:SetVar("drunk_turnCounter", 3)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == Attacking and Roll(0, 99) < 25 then
    char:TakeTrueDamage(char:GetMaxHP() * 0.1)
  elseif hookPoint == TakingDamage then
    param1 = param1 * 1.1
  end
end
