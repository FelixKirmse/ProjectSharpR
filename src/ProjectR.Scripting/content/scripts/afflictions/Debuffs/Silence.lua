function GetName()
  return "Silence"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { TurnTriggered }
end

function OnAttachment(char)
  char:SetSilenced(true)
  char:SetVar("sil_Chance", 1500)
end

function OnRemoval(char)
  char:SetSilenced(false)
end

function Trigger(hookPoint, char)
  if hookPoint ~= TurnTriggered then
    return
  end

  local silChance = char:GetVar("sil_Chance")
  local silResi = GetStats(char):GetTotalStat(SIL) * 3

  if Roll(0, 99) > silChance - silResi then
    this:RemoveFrom(char)
  else
    char:SetVar("sil_Chance", silChance / 3)
  end
end
