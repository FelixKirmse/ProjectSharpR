function GetName()
  return "Magic Resistant"
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
  if hookPoint == TakingDamage and GetCurrentSpell():GetSpellType() == Magical and Roll(0, 99) < 10 then
    param1 = 0
  end
end
