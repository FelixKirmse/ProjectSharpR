function GetName()
  return "Astral Imprisonment"
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
  if hookPoint == Attacking and Roll(0, 99) < 10 then
    param1:ApplyAffliction("Mini Stun")
  end
end
