function GetName()
  return "Dark Portal"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { TurnTriggered }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == TurnTriggered and Roll(0, 99) < 20 then
    SummonMinionCopy(char, "Imp")
  end
end
