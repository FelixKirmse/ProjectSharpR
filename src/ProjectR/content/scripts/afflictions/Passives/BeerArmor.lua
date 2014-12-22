function GetName()
  return "Beer Armor"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { TakingDamage }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == TakingDamage then
    param1 = param1 * 0.9

    if Roll(0, 99) < 5 then
      GetCurrentAttacker():ApplyAffliction("Drunk")
    end
  end
end
