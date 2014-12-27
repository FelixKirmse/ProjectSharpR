function GetName()
  return "Mini Stun"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { TurnCounterUpdating }
end

function OnAttachment(char)
  local parStrength = GetTimeToAction()

  char:SetVar("ministun_Strength", parStrength)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint ~= TurnCounterUpdating then
    return
  end

  local timeStep = GetStats(char):GetTotalStat(SPD)
  local currStrength = char:GetVar("ministun_Strength")
  local newStrength = currStrength - timeStep
  char:SetVar("ministun_Strength", newStrength)

  if newStrength <= 0 then
    this:RemoveFrom(char)
  end

  return false
end
