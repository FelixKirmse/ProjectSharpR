function GetName()
  return "Paralyze"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { TurnCounterUpdating }
end

function OnAttachment(char)
  local charPAR = GetStats(char):GetTotalStat(PAR) * 3

  if charPAR < 20 then
    charPAR = 20 -- We don't want to PAR them forever if they have low Resi, max 5 turns
  end

  local parStrength = GetTimeToAction() * (100 / charPAR);

  char:SetVar("par_Strength", parStrength)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint ~= TurnCounterUpdating then
    return
  end

  local timeStep = GetStats(char):GetTotalStat(SPD)
  local currStrength = char:GetVar("par_Strength")
  local newStrength = currStrength - timeStep
  char:SetVar("par_Strength", newStrength)

  if newStrength <= 0 then
    this:RemoveFrom(char)
  end
  return false
end
