function GetName()
    return "Drunk"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { Attacking }
end

function OnAttachment(char)
  char:SetVar("drunk_turnCounter", 3)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == Attacking then
    local drunkCounter = char:GetVar("drunk_turnCounter")

    if drunkCounter == 0 then
      this:RemoveFrom(char)
      return
    end

    drunkCounter = drunkCounter + 1

    if char:GetRace() == "Beerman" then
      param1 = param1 * 1.25
    elseif Roll(0, 99) < 25 then
      param1 = 0
    end

    char:SetVar("drunk_turnCounter", drunkCounter)
  end
end
