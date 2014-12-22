function GetName()
  return "Regeneration"
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
  if hookPoint ~= TurnTriggered then
    return
  end

  char:Heal(char:GetMaxHP() * 0.1)
end
