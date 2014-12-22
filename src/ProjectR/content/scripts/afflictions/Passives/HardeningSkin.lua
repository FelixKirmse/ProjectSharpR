function GetName()
  return "Hardening Skin"
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

  char:BuffStat(DEF, 0.2)
  char:BuffStat(MR, 0.2)
end
