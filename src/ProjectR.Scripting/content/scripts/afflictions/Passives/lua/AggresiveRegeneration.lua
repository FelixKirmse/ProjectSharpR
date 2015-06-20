function GetName()
  return "Aggressive Regeneration"
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

  local amount = (char:GetMaxHP() - char:GetCurrentHP()) * 0.25
  char:Heal(amount)
end
