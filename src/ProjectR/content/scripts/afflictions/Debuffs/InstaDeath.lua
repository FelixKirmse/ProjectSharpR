function GetName()
  return "InstaDeath"
end

function GetType()
  return Debuff
end

function GetHookPoints()
  return { }
end

function OnAttachment(char)
  char:TakeTrueDamage(char:GetCurrentHP() * 3)
  this:RemoveFrom(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
end
