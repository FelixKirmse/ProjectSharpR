function GetName()
  return "Kiss of Duplication"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { Attacking }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == Attacking and Roll(0, 99) < 5 then
    SummonMinionCopy(param1, param1:GetName())
  end
end
