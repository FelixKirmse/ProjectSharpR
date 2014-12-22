function GetName()
  return "Poison"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { TurnTriggered }
end

function OnAttachment(char)
end

function OnRemoval(char) -- Can only be removed by Cleansing Effects
end

function Trigger(hookPoint, char)
  if hookPoint ~= TurnTriggered then
    return
  end

  char:TakeTrueDamage(char:GetCurrentHP() * 0.2)

  if char:GetCurrentHP() <= 0 then
    char:Heal(1)
  end

end
