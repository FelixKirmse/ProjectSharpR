function GetName()
  return "Windfury"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { Attacking }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char, target, spell, damage, modifier, param5)
  if hookPoint == Attacking and param2:GetSpellType() == Physical and Roll(0, 99) < 2 then
    param3 = param3 + param2:Cast(char, param1, param4)
    param3 = param3 + param2:Cast(char, param1, param4)
  end
end
