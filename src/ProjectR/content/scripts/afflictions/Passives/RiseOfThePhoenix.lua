function GetName()
  return "Rise of the Phoenix"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { Dying }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint ~= TurnTriggered then
    return
  end

  char:Heal(char:GetMaxHP())
  char:UseMP(-200)

  for i = HP, SIL do
    char:BuffStat(i, 2)
  end

  this:RemoveFrom(char)
end
