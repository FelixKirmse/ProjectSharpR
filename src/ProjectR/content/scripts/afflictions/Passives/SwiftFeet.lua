function GetName()
  return "Swift Feet"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { RollingEvasion }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == RollingEvasion then
    param1 = param1 * 1.1
  end
end
