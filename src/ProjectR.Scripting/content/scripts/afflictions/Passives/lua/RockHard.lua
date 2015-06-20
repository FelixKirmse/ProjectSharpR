function GetName()
  return "Rock Hard"
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
  if hookPoint == TakingDamage and GetCurrentSpell():GetSpellType() == Physical and Roll(0, 99) < 20 then
    param1 = 0
  end
end
