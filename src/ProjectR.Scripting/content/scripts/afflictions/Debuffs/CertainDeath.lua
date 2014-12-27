function GetName()
  return "Certain Death"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { TurnTriggered }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == TurnTriggered then

    local deathCounter = char:GetVar("death_counter") - 1
    char:SetVar("death_counter", deathCounter)

    if deathCounter <= 0 then
      char:TakeTrueDamage(char:GetMaxHP() * 3)
      this:RemoveFrom(char)
    end
  end
end
