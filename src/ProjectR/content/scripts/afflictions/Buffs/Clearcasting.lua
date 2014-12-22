function GetName()
  return "Clearcasting"
end

function GetType()
  return Buff
end

function GetHookPoints()
  return { UsingMP }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == UsingMP then
    param1 = 0
  end
end
