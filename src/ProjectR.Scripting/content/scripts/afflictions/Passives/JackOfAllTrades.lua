function GetName()
  return "Jack Of All Trades"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { TurnTriggered, BuffingStat }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == TurnTriggered then
    char:UseMP(-10)
  end

  if hookPoint == BuffingStat then
    param2 = param2 * 1.5
  end
end
